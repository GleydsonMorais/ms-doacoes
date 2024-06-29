using ms_pessoa_domain.Dtos.Login;
using ms_pessoa_domain.Dtos.Pessoa;
using ms_pessoa_domain.Interfaces.Services;
using ms_pessoa_infra.Helpers;
using ms_pessoa_infra.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public LoginService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<QueryResult<LoginResDto>> LoginAsync(LoginReqDto dto)
        {
            var validaDto = ValidaDtoLogin(dto);
            if (!validaDto.Succeeded)
                return validaDto;

            var pessoa = await _pessoaRepository.GetByCPF(dto.CPF);
            if (pessoa == null)
            {
                return new QueryResult<LoginResDto>
                { 
                    Succeeded = false,
                    Message = "Usuário não cadastrado!"
                };
            }

            if (!pessoa.Senha.Equals(Convert.ToBase64String(Encoding.UTF8.GetBytes(dto.Senha))))
            {
                return new QueryResult<LoginResDto>
                {
                    Succeeded = false,
                    Message = "Senha incorreta!"
                };
            }

            return new QueryResult<LoginResDto>
            {
                Succeeded = true,
                Result = new LoginResDto
                { 
                    CPF = pessoa.CPF,
                    Token = "TOKEN"
                }
            };
        }

        #region Metodos Privados
        private QueryResult<LoginResDto> ValidaDtoLogin(LoginReqDto dto)
        {
            if (string.IsNullOrEmpty(dto.CPF))
            {
                return new QueryResult<LoginResDto>
                {
                    Succeeded = false,
                    Message = "O campo CPF é obrigatório!"
                };
            }

            if (string.IsNullOrEmpty(dto.Senha))
            {
                return new QueryResult<LoginResDto>
                {
                    Succeeded = false,
                    Message = "O campo Senha é obrigatório!"
                };
            }

            return new QueryResult<LoginResDto>
            {
                Succeeded = true
            };
        }
        #endregion
    }
}

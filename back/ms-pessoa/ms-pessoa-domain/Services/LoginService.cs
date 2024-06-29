using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ms_pessoa_domain.Dtos.Login;
using ms_pessoa_domain.Dtos.Pessoa;
using ms_pessoa_domain.Interfaces.Services;
using ms_pessoa_infra.Helpers;
using ms_pessoa_infra.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        private readonly IPessoaRepository _pessoaRepository;

        public LoginService(IConfiguration configuration, 
            IPessoaRepository pessoaRepository)
        {
            _configuration = configuration;
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
                    Nome = pessoa.Nome,
                    Token = GerarToken()
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

        private string GerarToken()
        {
            var _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var _issuer = _configuration["Jwt:Issuer"];
            var _audience = _configuration["Jwt:Audience"];

            var signinCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: new List<Claim>(),
                expires: DateTime.Now.AddHours(4),
                signingCredentials: signinCredentials);

            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }
        #endregion
    }
}

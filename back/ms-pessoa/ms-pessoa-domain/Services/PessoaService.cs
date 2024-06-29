﻿using ms_pessoa_domain.Dtos.Pessoa;
using ms_pessoa_domain.Interfaces.Services;
using ms_pessoa_infra.Entity;
using ms_pessoa_infra.Helpers;
using ms_pessoa_infra.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_domain.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository) 
        { 
            _pessoaRepository = pessoaRepository;
        }

        #region CadastraPessoaAsync
        public async Task<QueryResult<CadastraPessoaResDto>> CadastraPessoaAsync(CadastraPessoaReqDto dto)
        {
            var validaDto = ValidaDtoCadastro(dto);
            if (!validaDto.Succeeded)
                return validaDto;

            var entity = new Pessoa 
            {
                CPF = dto.CPF,
                Nome = dto.Nome,
                Senha = Convert.ToBase64String(Encoding.UTF8.GetBytes(dto.Senha)),
                Email = dto.Email,
                DtaInclusao = DateTime.Now
            };

            await _pessoaRepository.InsertAsync(entity);
            await _pessoaRepository.SaveAsync();

            return new QueryResult<CadastraPessoaResDto>
            { 
                Succeeded = true,
                Result = new CadastraPessoaResDto
                { 
                    CPF = entity.CPF, 
                    Nome = entity.Nome, 
                    Senha = Encoding.UTF8.GetString(Convert.FromBase64String(entity.Senha)), 
                    Email = entity.Email, 
                    DtaInclusao = entity.DtaInclusao
                }
            };
        }
        #endregion

        #region Metodos Privados
        private QueryResult<CadastraPessoaResDto> ValidaDtoCadastro(CadastraPessoaReqDto dto)
        {
            if (string.IsNullOrEmpty(dto.CPF))
            {
                return new QueryResult<CadastraPessoaResDto>
                {
                    Succeeded = false,
                    Message = "O campo CPF é obrigatório!"
                };
            }

            if (string.IsNullOrEmpty(dto.Nome))
            {
                return new QueryResult<CadastraPessoaResDto>
                {
                    Succeeded = false,
                    Message = "O campo Nome é obrigatório!"
                };
            }

            if (string.IsNullOrEmpty(dto.Senha))
            {
                return new QueryResult<CadastraPessoaResDto>
                {
                    Succeeded = false,
                    Message = "O campo Senha é obrigatório!"
                };
            }

            if (string.IsNullOrEmpty(dto.Email))
            {
                return new QueryResult<CadastraPessoaResDto>
                {
                    Succeeded = false,
                    Message = "O campo Email é obrigatório!"
                };
            }

            return new QueryResult<CadastraPessoaResDto>
            {
                Succeeded = true
            };
        }
        #endregion
    }
}
﻿using ms_pessoa_domain.Domains;
using ms_pessoa_domain.Dtos.Login;
using ms_pessoa_domain.Dtos.Pessoa;
using ms_pessoa_infra.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_domain.Interfaces.Services
{
    public interface IPessoaService
    {
        Task<QueryResult<CadastraPessoaResDto>> CadastraPessoaAsync(CadastraPessoaReqDto dto);
        Task<QueryResult<AlterarSenhaResDto>> AlterarSenhaAsync(string cpf, AlterarSenhaReqDto dto);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_domain.Dtos.Pessoa
{
    public class CadastraPessoaReqDto
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}

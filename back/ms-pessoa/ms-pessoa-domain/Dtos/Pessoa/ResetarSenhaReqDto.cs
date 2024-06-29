using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_domain.Dtos.Pessoa
{
    public class ResetarSenhaReqDto
    {
        public string SenhaAntiga { get; set; }
        public string SenhaNova { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_domain.Dtos.Login
{
    public class AlterarSenhaResDto
    {
        public string CPF { get; set; }
        public string Senha { get; set; }
        public DateTime? DtaAlteracao { get; set; }
    }
}

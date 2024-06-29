using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_infra.Entity
{
    public class Pessoa
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime DtaInclusao { get; set; }
        public DateTime? DtaAlteracao { get; set; }
    }
}

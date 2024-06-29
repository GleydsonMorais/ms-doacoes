using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_domain.Dtos.Login
{
    public class LoginReqDto
    {
        public string CPF { get; set; }
        public string Senha { get; set; }
    }
}

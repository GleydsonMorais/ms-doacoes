using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_domain.Dtos.Login
{
    public class LoginResDto
    {
        public string CPF { get; set; }
        public string Token { get; set; }
    }
}

using ms_pessoa_infra.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_unit_test.Mock
{
    public class PessoaMock
    {
        public static Pessoa PessoaResMock()
        {
            return new Pessoa
            { 
                CPF = "00000000000",
                Nome = "Nome Teste",
                Senha = "c2VuaGExMjM=",
                Email = "nome@email.com",
                DtaInclusao = DateTime.Now
            };
        }
    }
}

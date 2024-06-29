using ms_pessoa_domain.Dtos.Pessoa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_unit_test.Mock
{
    public class CadastraPessoaAsyncReqMock : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] 
            { 
                new CadastraPessoaReqDto
                { 
                    CPF = "00000000000",
                    Nome = "Nome Teste",
                    Senha = "Senha000",
                    Email = "nome@email.com"
                }
            }
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }
}

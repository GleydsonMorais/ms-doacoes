using ms_pessoa_domain.Dtos.Login;
using ms_pessoa_domain.Dtos.Pessoa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_unit_test.Mock
{
    public class AlterarSenhaAsyncReqMock : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                "00000000000",
                new AlterarSenhaReqDto
                {
                    SenhaAntiga = "senha123",
                    SenhaNova = "senha321"
                }
            }
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }
}

using ms_pessoa_infra.Contexts;
using ms_pessoa_infra.Entity;
using ms_pessoa_infra.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_infra.Repositories
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        private readonly MsPessoaContexto _dataContext;

        public PessoaRepository(MsPessoaContexto dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Pessoa> GetByCPF(string CPF) => await _dataContext.Pessoa.FindAsync(CPF);
    }
}

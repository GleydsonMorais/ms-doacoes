using ms_pessoa_infra.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_infra.Interfaces.Repositories
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        Task<Pessoa> GetByCPF(string CPF);
    }
}

using ms_pessoa_infra.Contexts;
using ms_pessoa_infra.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MsPessoaContexto _dataContext;

        public Repository(MsPessoaContexto dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task InsertAsync(T obj) => await _dataContext.AddAsync(obj);

        public void Update(T obj) => _dataContext.Update(obj);

        public void Delete(T obj) => _dataContext.Remove(obj);

        public async Task SaveAsync() => await _dataContext.SaveChangesAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_pessoa_infra.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task InsertAsync(T obj);
        void Update(T obj);
        void Delete(T obj);
        Task SaveAsync();
    }
}

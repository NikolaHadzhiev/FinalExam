using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Interfaces
{
    public interface IGenericCrudService<K, T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById();

        Task<T> Create(T model);

        Task<T> Update(K id, T model);

        Task<T> Delete(K id);
    }
}

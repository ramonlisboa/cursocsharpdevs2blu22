using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoNotas.Domain.Interfaces.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> FindAll();
        Task<T> FindById(int id);
        Task<int> Save(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }
}

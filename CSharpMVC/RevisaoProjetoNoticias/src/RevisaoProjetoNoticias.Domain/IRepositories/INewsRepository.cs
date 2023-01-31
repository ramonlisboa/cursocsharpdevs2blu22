using RevisaoProjetoNoticias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisaoProjetoNoticias.Domain.IRepositories
{
    public interface INewsRepository : IBaseRepository<News>
    {
        Task<int> SaveFile(int id, string fileName);
    }
}

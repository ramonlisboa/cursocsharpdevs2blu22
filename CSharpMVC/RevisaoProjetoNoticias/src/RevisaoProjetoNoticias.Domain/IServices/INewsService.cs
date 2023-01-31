using RevisaoProjetoNoticias.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisaoProjetoNoticias.Domain.IServices
{
    public interface INewsService : IBaseService<NewsDTO>
    {
        Task<int> SaveFile(int id, string file);
    }
}

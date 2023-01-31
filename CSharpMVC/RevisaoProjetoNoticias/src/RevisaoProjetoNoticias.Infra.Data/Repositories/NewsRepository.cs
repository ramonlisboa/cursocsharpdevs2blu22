using Microsoft.EntityFrameworkCore;
using RevisaoProjetoNoticias.Domain.Entities;
using RevisaoProjetoNoticias.Domain.IRepositories;
using RevisaoProjetoNoticias.Infra.Data.Context;

namespace RevisaoProjetoNoticias.Infra.Data.Repositories
{
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        private readonly SQLServerContext _context;
        public NewsRepository(SQLServerContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<int> SaveFile(int id, string fileName)
        {
            FormattableString sqlCommand = $"UPDATE [dbo].[News] SET Image = '{fileName}' WHERE Id = {id}";
            return await this._context.Database.ExecuteSqlInterpolatedAsync(sqlCommand);
        }
    }
}

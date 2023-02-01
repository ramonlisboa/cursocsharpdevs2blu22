using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models;
using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Repository
{
    public class CategoriaRepository
    {
        private readonly ContextoDatabase _context;

        public CategoriaRepository(ContextoDatabase context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categoria.ToListAsync();
        }

        public async Task<int> SaveCategoria(Categoria categoria)
        {
            _context.Add(categoria);
            return await _context.SaveChangesAsync();
        }

        internal async Task<int> DeleteCategoria(Categoria categoria)
        {
            _context.Categoria.Remove(categoria);
            return await _context.SaveChangesAsync();
        }

        internal async Task<Categoria> FindByIdCategoria(int id)
        {
            return await _context.Categoria.FindAsync(id);
        }
    }
}

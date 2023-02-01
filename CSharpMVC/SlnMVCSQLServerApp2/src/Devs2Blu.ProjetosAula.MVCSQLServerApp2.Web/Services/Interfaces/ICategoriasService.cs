using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities;

namespace Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Services.Interfaces
{
    public interface ICategoriasService
    {
        Task<int> Delete(Categoria categoria);
        Task<Categoria> FindById(int id);
        Task<IEnumerable<Categoria>> GetAllCategorias();
        Task<int> Save(Categoria categoria);
    }
}

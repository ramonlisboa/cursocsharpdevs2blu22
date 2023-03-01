using ProjetoNotas.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoNotas.Domain.Interfaces.IRepository
{
    public interface INoteService
    {
        List<NoteDTO> FindAll();
        Task<NoteDTO> FindById(int id);
        Task<int> Save(NoteDTO entity);
        Task<int> Update(NoteDTO entity);
        Task<int> Delete(NoteDTO entity);
    }
}

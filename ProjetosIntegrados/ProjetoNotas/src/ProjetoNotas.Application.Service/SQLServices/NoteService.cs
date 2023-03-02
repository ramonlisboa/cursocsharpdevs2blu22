using ProjetoNotas.Domain.DTO;
using ProjetoNotas.Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoNotas.Application.Service.SQLServices
{
    public class NoteService : INoteService
    {
        public NoteService() { }

        public Task<int> Delete(NoteDTO entity)
        {
            throw new NotImplementedException();
        }

        public List<NoteDTO> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<NoteDTO> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save(NoteDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(NoteDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}

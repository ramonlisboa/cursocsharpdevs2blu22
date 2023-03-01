using ProjetoNotas.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoNotas.Domain.Interfaces.IRepository
{
    public interface IUserService
    {
        List<UserDTO> FindAll();
        Task<UserDTO> FindById(int id);
        Task<int> Save(UserDTO entity);
        Task<int> Update(UserDTO entity);
        Task<int> Delete(UserDTO entity);
    }
}

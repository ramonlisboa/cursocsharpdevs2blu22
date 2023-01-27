using RevisaoProjetoNoticias.Domain.DTO;
using RevisaoProjetoNoticias.Domain.IRepositories;
using RevisaoProjetoNoticias.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisaoProjetoNoticias.Application.Service.SQLServerServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }

        public List<CategoryDTO> FindAll()
        {
            return _repository.FindAll()
                              .Select(c => new CategoryDTO()
                                        {
                                            id = c.Id,
                                            name = c.Name
                                        }).ToList();
        }

        public async Task<CategoryDTO> FindById(int id)
        {
            var dto = new CategoryDTO();
            return dto.mapToDTO(await _repository.FindById(id));
        }

        public Task<int> Save(CategoryDTO entity)
        {
            if (entity.id > 0)
            {
                return _repository.Update(entity.mapToEntity());
            } else
            {
                return _repository.Save(entity.mapToEntity());
            }
        }
    }
}

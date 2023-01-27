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
    public class NewsService : INewsService
    {
        private readonly INewsRepository _repository;

        public NewsService(INewsRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }

        public List<NewsDTO> FindAll()
        {
            return _repository.FindAll()
                              .Select(c => new NewsDTO()
                                        {
                                            id = c.Id,
                                            title = c.Title
                                        }).ToList();
        }

        public Task<NewsDTO> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save(NewsDTO dto)
        {
            return _repository.Save(dto.mapToEntity());
        }
    }
}

﻿using RevisaoProjetoNoticias.Domain.DTO;
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

        public Task<int> Delete(CategoryDTO entity)
        {
            throw new NotImplementedException();
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

        public Task<CategoryDTO> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save(CategoryDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
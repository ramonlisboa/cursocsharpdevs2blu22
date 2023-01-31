using RevisaoProjetoNoticias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisaoProjetoNoticias.Domain.DTO
{
    public class NewsDTO
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please, set a title.")]
        [MinLength(3, ErrorMessage = "Title should bigger than 3 charactere")]
        public string title { get; set; }
        public string description { get; set; }
        public int categoryId { get; set; }
        public DateTime? createdOn { get; set; }
        public bool published { get; set; }
        public virtual CategoryDTO? category { get; set; }
        public string? image { get; set; }

        public News mapToEntity()
        {
            return new News(){
                Id = id,
                Title = title,
                Description = description,
                CategoryId = categoryId,
                CreatedOn = createdOn,
                Published = published,
                Image = image
            };
        }
        public NewsDTO mapToDTO(News news)
        {
            return new NewsDTO()
            {
                id = news.Id,
                title = news.Title,
                description = news.Description,
                categoryId = news.CategoryId,
                createdOn = news.CreatedOn,
                published = news.Published,
                image = news.Image
                /*category = new CategoryDTO()
                {
                    id = news.Category.Id,
                    name = news.Category.Name
                }*/
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisaoProjetoNoticias.Domain.Entities
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool Published { get; set; }
        public virtual Category? Category { get; set; }
        public string? Image { get; set; }
    }
}

using ProjetoNotas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoNotas.Domain.DTO
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CategoryEnum Category { get; set; }
        public bool Fixed { get; set; }
        public DateTime TimeNote { get; set; }

        public virtual UserDTO? User { get;set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devs2Blu.ProjetosAula.MVCSQL.Web.Models.Entities
{
    [Table("filmes")]
    public class Filme
    {
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("title")]
        [Display(Name = "Título")]
        public string Title { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities
{
    [Table("produtos")]
    public class Produto
    {
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("preco")]
        [Display(Name = "Preço")]
        public Double Preco { get; set; }

        [Column("quantidade")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Column("CategoriaId")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [Display(Name = "Marca")]
        public int? MarcaId { get; set; }
        
        public virtual Categoria? Categoria { get; set; }
        public virtual Marca? Marca { get; set; }
    }
}

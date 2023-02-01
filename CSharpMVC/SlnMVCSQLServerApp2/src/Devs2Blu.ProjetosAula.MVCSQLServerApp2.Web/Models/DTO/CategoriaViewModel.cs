using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.ViewModel
{
    public class CategoriaViewModel
    {
        [Display(Name = "Código")]
        public int id { get; set; }

        [Display(Name = "Nome")]
        public string nome { get; set; }

        public Categoria ToEntity()
        {
            return new Categoria()
            {
                Id = id,
                Nome = nome
            };
        }
    }
}

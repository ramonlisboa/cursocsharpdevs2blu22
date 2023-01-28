using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RevisaoProjetoNoticias.Web.Models.DTO
{
    public class ImageFieldNews
    {
        public int idNews { get; set; }

        [DataType(DataType.Upload)]
        [DisplayName("Upload Image")]
        public string? imageNews { get; set; }
    }
}

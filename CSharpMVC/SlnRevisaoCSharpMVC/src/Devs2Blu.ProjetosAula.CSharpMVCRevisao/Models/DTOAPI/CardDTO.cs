namespace Devs2Blu.ProjetosAula.CSharpMVCRevisao.Models.DTOAPI
{
    public class CardDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Desc { get; set; }
        public List<CardImagesDTO> Card_Images { get; set; }
    }
}
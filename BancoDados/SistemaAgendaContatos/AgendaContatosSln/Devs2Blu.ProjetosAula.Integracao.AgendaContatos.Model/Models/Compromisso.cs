using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Models
{
    public class Compromisso
    {
        public int Id { get; set; }
        public Contato Contato { get; set; }
        public string Titulo { get; set; }
        public string Descricacao { get; set; }
        public DateTime DataIni { get; set; }
        public DateTime DataFim { get; set; }
        public StatusEnum Status { get; set; }

        public Compromisso()
        {
            Contato = new Contato();
        }

        public Compromisso(int id, Contato contato, string titulo, string descricacao, DateTime dataIni, DateTime dataFim, StatusEnum status)
        {
            Id = id;
            Contato = contato;
            Titulo = titulo;
            Descricacao = descricacao;
            DataIni = dataIni;
            DataFim = dataFim;
            Status = status;
        }
    }
}

using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public StatusEnum Status { get; set; }

        public Contato()
        {

        }

        public Contato(Int32? id, String nome, String telefone, String celular, String email, String rua, Int32? numero, String bairro, String cidade, String uF, StatusEnum? status)
        {
            Id = (int)id;
            Nome = nome;
            Telefone = telefone;
            Celular = celular;
            Email = email;
            Rua = rua;
            Numero = (int)numero;
            Bairro = bairro;
            Cidade = cidade;
            UF = uF;
            Status = (StatusEnum)status;
        }

        public Contato(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Classes
{
    public class Recepcionista : Pessoa
    {
        public int NumeroCracha { get; set; }

        public Recepcionista() 
        {
            Nome = "NOVO";
            SobreNome = "RECEPCIONISTA";
            NumeroCracha = 999999;
        }
        public Recepcionista(string Nome, string sobreNome) 
        {
            this.Nome = Nome;
            SobreNome = sobreNome;
        }
        public Recepcionista(int numeroCracha, string endereco)
        {
            NumeroCracha = numeroCracha;
            Endereco = endereco;
        }

        public string AgendarConsulta()
        {
            return $"Consulta Agendada!";
        }
    }
}

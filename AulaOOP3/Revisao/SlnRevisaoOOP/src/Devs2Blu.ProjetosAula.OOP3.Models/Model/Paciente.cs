using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Models.Model
{
    public class Paciente : Pessoa
    {
        public Int32 CodigoPaciente { get; set; }
        public String Convenio { get; set; }
    }
}

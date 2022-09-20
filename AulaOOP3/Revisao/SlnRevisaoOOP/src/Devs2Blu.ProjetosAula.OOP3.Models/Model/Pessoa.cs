using Devs2Blu.ProjetosAula.OOP3.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Models.Model
{
    public abstract class Pessoa
    {
        public Int32 Codigo { get; set; }
        public String Nome { get; set; }
        public String CGCCPF { get; set; }
        public String Endereco { get; set; }
        public TipoPessoa TipoPessoa { get; set; }

    }
}

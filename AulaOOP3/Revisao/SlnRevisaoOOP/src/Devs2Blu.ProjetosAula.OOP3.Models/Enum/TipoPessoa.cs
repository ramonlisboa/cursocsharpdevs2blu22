using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Models.Enum
{
    public enum TipoPessoa
    {
        [Description("Pessoa Física")]
        PF = 1,
        [Description("Pessoa Jurídica")]
        PJ = 2
    }
}

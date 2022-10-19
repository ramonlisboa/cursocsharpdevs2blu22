using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Enum
{
    public enum StatusEnum
    {
        [Description("Inativo")]
        I,
        [Description("Ativo")]
        A,
        [Description("Concluído")]
        C,
        [Description("Remarcado")]
        R
    }
}

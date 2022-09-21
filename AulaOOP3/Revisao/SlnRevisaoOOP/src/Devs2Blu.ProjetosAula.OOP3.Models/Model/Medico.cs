using Devs2Blu.ProjetosAula.OOP3.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Models.Model
{
    public class Medico : Pessoa
    {
        public Int32 CodigoMedico { get; set; }
        public Int32 CRM { get; set; }
        public String Especialidade { get; set; }

        public Medico()
        {
            TipoPessoa = TipoPessoa.PF;
        }

        public Medico(Int32 codigo, String nome, String cpf, Int32 crm, String especialidade)
        {
            Codigo = codigo;
            Nome = nome;
            CGCCPF = cpf;
            TipoPessoa = TipoPessoa.PF;
            CRM = crm;
            Especialidade = especialidade;

            Random rd = new Random();
            CodigoMedico = Int32.Parse($"{codigo}{rd.Next(10, 100)}");
        }
    }
}

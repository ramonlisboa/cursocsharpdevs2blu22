using Devs2Blu.ProjetosAula.SistemaCadastro.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.SistemaCadastro.Models.Model
{
    public class Pessoa
    {
        public Int32 Id { get; set; }
        public String Nome { get; set; }
        public String CGCCPF { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public FlStatus Status { get; set; }

        public Pessoa()
        {
            Status = FlStatus.A;
        }

        public Pessoa(int id, string nome, string cGCCPF, TipoPessoa tipoPessoa, FlStatus status)
        {
            Id = id;
            Nome = nome;
            CGCCPF = cGCCPF;
            TipoPessoa = tipoPessoa;
            Status = status;
        }
    }
}

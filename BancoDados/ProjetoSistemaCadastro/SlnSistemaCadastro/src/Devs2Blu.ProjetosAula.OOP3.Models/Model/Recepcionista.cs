using Devs2Blu.ProjetosAula.SistemaCadastro.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.SistemaCadastro.Models.Model
{
    public class Recepcionista : Pessoa
    {
        public Int32 CodigoRecepcionista { get; set; }
        public String Setor { get; set; }

        public Recepcionista()
        {
            TipoPessoa = TipoPessoa.PF;
        }

        public Recepcionista(Int32 codigo, String nome, String cpf, string setor)
        {
            Codigo = codigo;
            Nome = nome;
            CGCCPF = cpf;
            TipoPessoa = TipoPessoa.PF;
            Setor = setor;

            Random rd = new Random();
            CodigoRecepcionista = Int32.Parse($"{codigo}{rd.Next(1000, 1100)}");
        }
    }
}

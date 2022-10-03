using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Interfaces
{
    public interface IMenuCadastro
    {
        Int32 MenuCadastro();
        void Listar();
        void Cadastrar();
        void Alterar();
        void Excluir();
    }
}

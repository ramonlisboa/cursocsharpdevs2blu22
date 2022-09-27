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
        void MenuCadastro();
        void Listar();
        void Cadastrar(Pessoa pessoa);
        void Alterar(Pessoa pessoa);
        void Excluir(Pessoa pessoa);
    }
}

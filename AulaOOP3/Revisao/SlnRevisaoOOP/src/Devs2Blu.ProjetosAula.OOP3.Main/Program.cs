using Devs2Blu.ProjetosAula.OOP3.Main.Cadastros;
using Devs2Blu.ProjetosAula.OOP3.Main.Interfaces;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils.Enums;
using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Main
{
    class Program
    {
        public static Mocks Mock { get; set; }
        static void Main(string[] args)
        {
            Int32 opcao = (int)MenuEnums.SAIR, opcaoMenuCadastros = (int)MenuEnums.SAIR;
            Mock = new Mocks();
            IMenuCadastro menuCadastros;

            do
            {

                if (opcaoMenuCadastros.Equals((int)MenuEnums.SAIR))
                {
                    Console.Clear();
                    Console.WriteLine("----- Sistema de Gerencimento de Clínicas -----");
                    Console.WriteLine("----- 10 - Cadastro de Pacientes -----");
                    Console.WriteLine("----- 20 - Cadastro de Médicos -----");
                    Console.WriteLine("----- 30 - Cadastro de Recepcionistas -----");
                    Console.WriteLine("----- 40 - Cadastro de Fornecedores -----");
                    Console.WriteLine("----- 50 - Agenda -----");
                    Console.WriteLine("----- 60 - Prontuário -----");
                    Console.WriteLine("----- 70 - Financeiro -----");
                    Console.WriteLine("---------------------");
                    Console.WriteLine("----- 0 - Sair -----");
                    Int32.TryParse(Console.ReadLine(), out opcao);
                }

                switch (opcao)
                {
                    case (int)MenuEnums.CAD_PAC:
                        menuCadastros = new CadastroPaciente();
                        opcaoMenuCadastros = menuCadastros.MenuCadastro();
                        break;
                    case (int)MenuEnums.CAD_MED:
                        menuCadastros = new CadastroMedico();
                        opcaoMenuCadastros = menuCadastros.MenuCadastro();
                        break;
                    default:
                        menuCadastros = new CadastroPadrao();
                        opcaoMenuCadastros = (int)MenuEnums.SAIR;
                        break;
                }

                switch (opcaoMenuCadastros)
                {
                    case (int)MenuEnums.LISTAR:
                        menuCadastros.Listar();
                        break;
                    case (int)MenuEnums.CADASTRAR:
                        menuCadastros.Cadastrar();
                        break;
                    case (int)MenuEnums.ALTERAR:
                        menuCadastros.Alterar();
                        break;
                    case (int)MenuEnums.EXCLUIR:
                        menuCadastros.Excluir();
                        break;
                    default:
                        opcaoMenuCadastros = (int)MenuEnums.SAIR;
                        break;
                }
            } while (!opcao.Equals((int)MenuEnums.SAIR));
        }

    }
}

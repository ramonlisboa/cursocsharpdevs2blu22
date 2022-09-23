using Devs2Blu.ProjetosAula.OOP3.Main.Utils.Enums;
using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Cadastros
{
    public class CadastroMedico
    {
        public void MenuCadastro()
        {
            Int32 opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("----- Cadastro de Medicos -----");
                Console.WriteLine("----- 1- Lista de Medicos -----");
                Console.WriteLine("----- 2- Cadastro de Medicos -----");
                Console.WriteLine("----- 3- Alterar Medicos -----");
                Console.WriteLine("---------------------");
                Console.WriteLine("----- 0- Sair -----");
                Int32.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case (int)MenuEnums.LISTAR:
                        ListarMedicos();
                        break;
                    default:
                        break;
                }

            } while (!opcao.Equals((int)MenuEnums.SAIR));
        }

        public void ListarMedicos()
        {
            Console.Clear();

            foreach (var medico in Program.Mock.ListaMedicos)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Medico: {medico.CodigoMedico}");
                Console.WriteLine($"Nome: {medico.Nome}");
                Console.WriteLine($"Especialidade: {medico.Especialidade}");
                Console.WriteLine($"CRM: {medico.CRM}");
                Console.WriteLine("-----------------------------------------\n");
            }
            Console.ReadLine();
        }

        public void CadastrarMedico()
        {

        }

        public void AlterarMedico()
        {

        }

        public void ExcluirMedico()
        {

        }
    }
}

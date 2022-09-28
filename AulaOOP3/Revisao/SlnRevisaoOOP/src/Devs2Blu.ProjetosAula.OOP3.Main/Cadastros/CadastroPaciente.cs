using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devs2Blu.ProjetosAula.OOP3.Main.Interfaces;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils.Enums;
using Devs2Blu.ProjetosAula.OOP3.Models.Model;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Cadastros
{
    public class CadastroPaciente : IMenuCadastro
    {
        public CadastroPaciente()
        {

        }
        private void ListarPacientes()
        {
            Console.Clear();

            foreach (Paciente paciente in Program.Mock.ListaPacientes)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Paciente: {paciente.CodigoPaciente}");
                Console.WriteLine($"Nome: {paciente.Nome}");
                Console.WriteLine($"CPF: {paciente.CGCCPF}");
                Console.WriteLine($"Convenio: {paciente.Convenio}");
                Console.WriteLine("-----------------------------------------\n");
            }
            Console.ReadLine();
        }

        private void CadastrarPaciente(Paciente novoPaciente)
        {
            Program.Mock.ListaPacientes.Add(novoPaciente);
        }

        private void AlterarPaciente(Paciente paciente)
        {
            var pact = Program.Mock.ListaPacientes.Find(p => p.CodigoPaciente == paciente.CodigoPaciente);
            int index = Program.Mock.ListaPacientes.IndexOf(pact);
            Program.Mock.ListaPacientes[index] = paciente;
        }

        private void ExcluirPaciente(Paciente paciente)
        {
            Program.Mock.ListaPacientes.Remove(paciente);
        }
        private void ListarPacientesByCodeAndName()
        {
            foreach (Paciente paciente in Program.Mock.ListaPacientes)
            {
                Console.Write($"| {paciente.CodigoPaciente} - {paciente.Nome} ");
            }
            Console.WriteLine("\n");
        }


        #region FACADE
        public Int32 MenuCadastro()
        {
            Int32 opcao;
            Console.Clear();
            Console.WriteLine("----- Cadastro de Pacientes -----");
            Console.WriteLine("----- 1- Lista de Pacientes -----");
            Console.WriteLine("----- 2- Cadastro de Pacientes -----");
            Console.WriteLine("----- 3- Alterar Pacientes -----");
            Console.WriteLine("---------------------");
            Console.WriteLine("----- 0- Sair -----");
            Int32.TryParse(Console.ReadLine(), out opcao);
            return opcao;
        }

        public void Listar()
        {
            ListarPacientes();
        }

        public void Cadastrar()
        {
            Console.Clear();
            Paciente paciente = new Paciente();
            Console.WriteLine("Informe o Nome do Paciente");
            paciente.Nome = Console.ReadLine();

            Console.WriteLine("Informe o CPF do Paciente");
            paciente.CGCCPF = Console.ReadLine();

            Console.WriteLine("Informe o Convênio do Paciente");
            paciente.Convenio = Console.ReadLine();

            Random rd = new Random();
            paciente.Codigo = rd.Next(1, 100) + DateTime.Now.Second;
            paciente.CodigoPaciente = Int32.Parse($"{paciente.Codigo}{rd.Next(100, 999)}");

            CadastrarPaciente(paciente);
        }

        public void Alterar()
        {
            Console.Clear();
            Paciente paciente;
            int codigoPaciente;

            Console.WriteLine("Informe o Paciente que Deseja Alterar:\n");
            ListarPacientesByCodeAndName();

            Int32.TryParse(Console.ReadLine(), out codigoPaciente);

            paciente = Program.Mock.ListaPacientes.Find(p => p.CodigoPaciente == codigoPaciente);

            string opcaoAlterar;
            bool alterar = true;

            do
            {
                Console.WriteLine($"Paciente: {paciente.Codigo}/{paciente.CodigoPaciente} | Nome: {paciente.Nome} | CPF: {paciente.CGCCPF} | Convênio: {paciente.Convenio}");
                Console.WriteLine("Qual campo deseja alterar?");
                Console.WriteLine("01 - Nome | 02 - CPF | 03 Convênio | 00 - SAIR");
                opcaoAlterar = Console.ReadLine();

                switch (opcaoAlterar)
                {
                    case "01":
                        Console.WriteLine("Informe um novo nome:");
                        paciente.Nome = Console.ReadLine();
                        break;
                    case "02":
                        Console.WriteLine("Informe um novo CPF:");
                        paciente.CGCCPF = Console.ReadLine();
                        break;
                    case "03":
                        Console.WriteLine("Informe um novo Convênio:");
                        paciente.Convenio = Console.ReadLine();
                        break;
                    default:
                        alterar = false;
                        break;
                }

                if(alterar)
                {
                    Console.Clear();
                    Console.WriteLine("Dado Alterado com Sucesso!");
                }
            } while (alterar);

            AlterarPaciente(paciente);
        }

        public void Excluir()
        {
            Paciente paciente = new Paciente();
            ExcluirPaciente(paciente);
        }

        #endregion
    }
}

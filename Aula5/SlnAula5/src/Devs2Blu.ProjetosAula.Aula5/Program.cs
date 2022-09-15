using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Aula5
{
    class Program
    {
        const string A21 = "A21";
        const string A22 = "A22";
        const string A23 = "A23";
        const string A24 = "A24";
        const string A35 = "A35";
        const string Z16 = "Z16";
        static void Main(string[] args)
        {
            
        }
        static void ExercicioSwitch5()
        {
            const int PT7 = 10;
            const int PT14 = 20;
            const int PT21 = 30;
            const int PT1a6 = 1;
            const int PT8a13 = 5;
            const int PT15a20 = 6;
            
            int optUsuario, optPC, numeroAleatorio;
            int resultUsuario, resultPC;

            Console.WriteLine("******************");
            Console.WriteLine("| JOGO DO 21   |");
            Console.WriteLine("******************");

            Console.WriteLine("Escolha um número de 1 à 20.");

            // Usuário escolhe um número
            Int32.TryParse(Console.ReadLine(), out optUsuario);
            
            // O computador (oponente) "escolhe" um número
            Random rd = new Random();
            optPC = rd.Next(1, 20);

            // O computador gera um número aleatório
            numeroAleatorio = rd.Next(1, 20);

            // Pontuação do Usuário
            switch (optUsuario)
            {
                case int i when (i<=6):
                    resultUsuario = PT1a6;
                    break;
                case 7:
                    resultUsuario = PT7;
                    break;

                default:
                    break;
            }
        }
        static void ExercicioSwitch1()
        {
            string fruta;

            Console.WriteLine("Escolha uma fruta:");
            Console.WriteLine("Maçã");
            Console.WriteLine("Kiwi");
            Console.WriteLine("Melancia");

            fruta = Console.ReadLine();

            switch (fruta.ToUpper())
            {
                case "MAÇÃ":
                    Console.WriteLine("Não vendemos essa fruta aqui.");
                    break;
                case "KIWI":
                    Console.WriteLine("Estamos com escassez de Kiwis");
                    break;
                case "MELANCIA":
                    Console.WriteLine("Aqui está, são R$ 3,00 reais o Kilo!");
                    break;
                default:
                    Console.WriteLine("Produto inválido!");
                    break;
            }
        }
        
        static void Exemplo1()
        {
            /*
             *  - "A23" : Materiais
                - "A35": Produtos Perecíveis
                - "Z16": Produtos Químicos
             */
            string codigo;

            Console.WriteLine("Escolha um código para ver a descrição");
            Console.WriteLine("- A21");
            Console.WriteLine("- A22");
            Console.WriteLine("- A23");
            Console.WriteLine("- A24");
            Console.WriteLine("- A35");
            Console.WriteLine("- Z16");

            codigo = Console.ReadLine();

            switch (codigo.ToUpper())
            {
                case A21:
                case A22:
                case A23:
                case A24:
                    Console.WriteLine("Materiais.");
                    break;
                case A35:
                    Console.WriteLine("A35: Produtos Perecíveis.");
                    break;
                case Z16:
                    Console.WriteLine("Z16: Produtos Químicos.");
                    break;

                default:
                    Console.WriteLine("Produto Não Cadastrado.");
                    break;
            }
        }
    }
}

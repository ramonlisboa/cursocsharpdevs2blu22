using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2Blu.ProjetosAula.Aula6Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int controle = 0;

            do {
                Console.WriteLine("Informe um dos códigos Abaixo");
                Console.WriteLine("1 - Exemplo1");
                Console.WriteLine("2 - Exemplo2");
                Console.WriteLine("3 - Exercício 1");
                Console.WriteLine("4 - Exercício 2");
                Console.WriteLine("5 - Exercício 3");
                Int32.TryParse(Console.ReadLine(), out controle);

                switch (controle)
                {
                    case 1:
                        Exemplo1();
                        break;
                    case 2:
                        Exemplo2();
                        break;
                    case 3:
                        Exercicio1();
                        break;
                    case 4:
                        Exercicio2();
                        break;
                    case 5:
                        Exercicio3();
                        break;
                    default:
                        break;
                }

            } while (controle > 0);
        }

        static void Exercicio1()
        {
            int contador = 1;
            
            Console.WriteLine("Programa que mostra números ímpares de 1 a 100.");

            while (contador <= 100)
            {
                if (contador % 2 == 0) // contador - contador/2*2 != 0 OU !(contador % 2 == 0)
                {
                    Console.Write($"{contador}, ");
                }
                contador++;
            }
        }

        static void Exercicio2()
        {
            int contador = 1;

            Console.WriteLine("Programa que mostra números pares de 1 a 100.");

            while (contador <= 100)
            {
                if (contador % 2 == 0) // contador - contador/2*2 == 0
                {
                    Console.Write($"{contador}, ");
                }
                contador++;
            }
        }

        static void Exercicio3()
        {
            Console.Clear();
            int numeroLimite;
            int contador = 1;

            Console.WriteLine("Informe um número limite");
            Int32.TryParse(Console.ReadLine(), out numeroLimite);
            Console.WriteLine("Números ímpares?");
            while (contador <= numeroLimite)
            {
                if (contador % 2 != 0) // contador - contador/2*2 != 0 OU !(contador % 2 != 0)
                {
                    Console.Write($"{contador}, ");
                }
                contador++;
            }

            Console.WriteLine("\nNúmeros pares?");
            contador = 1;
            while (contador <= numeroLimite)
            {
                if (contador % 2 == 0) // contador - contador/2*2 == 0 OU !(contador % 2 == 0)
                {
                    Console.Write($"{contador}, ");
                }
                contador++;
            }
        }
        static void Exemplo1()
        {
            int controle = 1;

            while (controle > 0)
            {
                Console.WriteLine("Informe o código 0 para sair");
                Int32.TryParse(Console.ReadLine(), out controle);
            } 
        }

        static void Exemplo2()
        {
            Console.WriteLine("Exemplo 2");
        }
    }
}

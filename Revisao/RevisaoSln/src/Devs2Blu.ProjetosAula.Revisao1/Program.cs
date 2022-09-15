using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Revisao1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***# Escolhe o Programa #***\n");
            Console.WriteLine("***# 001 - Exemplo 1 #***");
            Console.WriteLine("***# 002 - Exemplo 2 #***");
            Console.WriteLine("***# 003 - Exemplo 3 #***");
            string codigoPrograma = Console.ReadLine() ;

            switch (codigoPrograma)
            {
                case "001":
                    Exemplo1();
                    break;
                case "002":
                    Exemplo2();
                    break;
                case "003":
                    Exemplo3();
                    break;

                default:
                    break;
            }
        }

        static void ExercicioW1()
        {
            int numero = 1;

            while (numero <=100)
            {
                if (!(numero - numero / 2 * 2 == 0)) // !(numero % 2 == 0)
                {
                    Console.Write($"{numero},");
                }

                numero++;
            }
        }

        static void Exemplo3()
        {
            Console.WriteLine("Exemplo usando While");
            int somaValores = 0, quantidadeValores, contador = 1;
            Random rd = new Random();

            Console.WriteLine("Informe a quantidade de valores para serem somados:");
            Int32.TryParse(Console.ReadLine(), out quantidadeValores);

            while (contador <= quantidadeValores)
            {
                int valor = rd.Next(5, 10);
                Console.Write($"{valor}, ");
                somaValores += valor;
                contador++;
            }

            int mediaAlunos = somaValores / quantidadeValores; 

            Console.WriteLine($"\nSomatório = {somaValores}");
        }
        static void Exemplo2()
        {
            Console.WriteLine("Exemplo Usando IF");
            Int32 valor1, valor2, valor3, maiorValor = 0;
            Random objRandom;
            objRandom = new Random();

            valor1 = objRandom.Next(1, 200);
            valor2 = objRandom.Next(1, 200);
            valor3 = objRandom.Next(1, 200);

            Console.WriteLine($"Valor 1: {valor1}");
            Console.WriteLine($"Valor 2: {valor2}");
            Console.WriteLine($"Valor 3: {valor3}");

            if(valor1 > maiorValor)
            {
                maiorValor = valor1;
            }
            if(valor2 > maiorValor)
            {
                maiorValor = valor2;
            }
            if (valor3 > maiorValor)
            {
                maiorValor = valor3;
            }

            Console.WriteLine($"O Maior Valor é {maiorValor}");
        }
        static void Exemplo1()
        {
            const double VR_ALELO = 625.50;
            const float CONTRIBUICAO_SINDICAL = 123.35f;
            const string NOME_EMPRESA = "PulsaTI Care";
            const string CNPJ = "31.123.456/0001-25";
            const int ANO_FUNDACAO = 2008;

            string userName;
            int userAge;
            double userSalary;

            Console.WriteLine("Informe seu nome:");
            userName = Console.ReadLine();

            Console.WriteLine("Infome sua idade:");
            Int32.TryParse(Console.ReadLine(), out userAge);

            Console.WriteLine("Informe seu salário:");
            Double.TryParse(Console.ReadLine(), out userSalary);

            Console.WriteLine("********************");
            Console.WriteLine($"**Nome: {userName}*");
            Console.WriteLine($"**Idade:{userAge}**");
            Console.WriteLine($"**Salário: {userSalary}*");
            Console.WriteLine("********************");
        }
    }
}

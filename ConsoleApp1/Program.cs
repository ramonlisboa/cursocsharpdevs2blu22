using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaração de variáveis
            string formatacaoDados = "Inicialização de Variável...\n";
            string nomeUsuario, cidadeUsuario;

            // Entrada de dados
              // - Nome
            Console.Write("Informe seu nome:");
            nomeUsuario = Console.ReadLine();

              // - Cidade
            Console.Write("Informe sua cidade:");
            cidadeUsuario = Console.ReadLine();
            
            // Processamento
              // - Boas vindas (Nome)
            formatacaoDados += "Seja bem-vindo, " + nomeUsuario + "!\n\n";

              // - Cidade do Usuário
            formatacaoDados += $"Localidade: {cidadeUsuario}";

            // Apresentação dos dados
            Console.WriteLine(formatacaoDados);

            // Pausa antes de encerrar
            Console.WriteLine("Pressione qualquer tecla para sair...");
            var input = Console.ReadLine();
        }
    }
}

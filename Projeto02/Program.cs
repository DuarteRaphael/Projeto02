// See https://aka.ms/new-console-template for more information
using Projeto02.Controllers;

namespace Projeto02
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var funcionarioController = new FuncionarioController();
                funcionarioController.CadastrarFuncionario();
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nOcorreu um erro: {e.Message}");
            }

            //pausar
            Console.ReadKey();
        }
    }
}


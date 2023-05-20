using Projeto02.Entities;
using Projeto02.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Controllers
{
    public class FuncionarioController
    {
        //método para fazer com que o usuário entre com os dados do funcionário.
        public void CadastrarFuncionario()
        {
            Console.WriteLine("\n --- CADASTRO DE FUNCIONÁRIO --- \n");
            
            //criando um objeto da classe Funcionário
            var funcionario = new Funcionario();

            //instaciar os relacionamentos contidos em funcionários.
            funcionario.Setor = new Setor();
            funcionario.Dependentes = new List<Dependente>();

            //gerando um Id para o funcionário
            funcionario.IdFuncionario = Guid.NewGuid();

            Console.Write("Nome do funcionário.............: ");
            funcionario.Nome = Console.ReadLine();

            Console.Write("CPF do funcionário..............: ");
            funcionario.CPF = Console.ReadLine();

            Console.Write("Matrícula do funcionário........: ");
            funcionario.Matricula = Console.ReadLine();

            Console.Write("Data de admissão do funcionário.: ");
            funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

            //gerando um id para o setor do funcionário
            funcionario.Setor.IdSetor = Guid.NewGuid();

            Console.Write("Nome do setor.........: ");
            funcionario.Setor.Nome = Console.ReadLine();

            Console.Write("Descrição do setor.....: ");
            funcionario.Setor.Descricao = Console.ReadLine();

            //solicitar que o usuário informe o número de dependentes desejado.
            Console.Write("\nNúmero de dependentes.........: ");
            var numDependentes = int.Parse(Console.ReadLine());

            //percorrer o número de dependentes informados.
            for (int i = 0; i < numDependentes; i++)
            {
                //criando um objeto do tipo dependente
                var dependente = new Dependente();

                //gerando um id para o dependente.
                dependente.IdDependente = Guid.NewGuid();

                Console.Write($"\nENTRE COM O {i+1}º DEPENDENTE:\n");
                
                Console.Write("Nome do dependente..........: ");
                dependente.Nome = Console.ReadLine();

                Console.Write("Data de nascimento..........: ");
                dependente.DataNascimento = DateTime.Parse(Console.ReadLine());

                //adicionar o dependente na lista.
                funcionario.Dependentes.Add(dependente);
            }
            //gravar os dados do funcionário em um arquivo JSON
            var funcionarioRepository = new FuncionarioRepository();
            funcionarioRepository.ExportarJSON(funcionario);

            try
            {
                Console.WriteLine("\nArquivo JSON gerado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }
        }
    }
}

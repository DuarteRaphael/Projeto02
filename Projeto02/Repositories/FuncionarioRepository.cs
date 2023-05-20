using Projeto02.Entities;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Projeto02.Repositories
{
    public class FuncionarioRepository
    {
        //receber um objeto do tipo funcionário e gravar os seus dados em um arquivo do tipo de extensão JSON
        public void ExportarJSON(Funcionario funcionario)
        {
            var path = $"c:\\temp\\funcionario_{funcionario.IdFuncionario}.json";
            var streamWriter = new StreamWriter(path);

            //serializar os dados do funcionário para JSON.
            var json = JsonConvert.SerializeObject(funcionario);

            //escrevendo no arquivo
            streamWriter.WriteLine(json);

            //fechando o arquivo
            streamWriter.Close();
        }
    }
}

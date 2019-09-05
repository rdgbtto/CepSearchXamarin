using System.Net;
using CepSearch.Servico.Modelo;
using Newtonsoft.Json;

namespace CepSearch.Servico
{
    public class ViaCepServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEndereco(string cep)
        {
            string novoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient webClient = new WebClient();
            string conteudo = webClient.DownloadString(novoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            return end.Cep == null ? null : end;
        }
    }
}

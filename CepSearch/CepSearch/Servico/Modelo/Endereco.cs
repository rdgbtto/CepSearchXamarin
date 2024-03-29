﻿namespace CepSearch.Servico.Modelo
{
    public class Endereco
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Unidade { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }

        public override string ToString()
        {
            return "CEP: " + Cep + 
                   "\nEndereço: " + Logradouro +
                   "\nBairro: " + Bairro +
                   "\nLocalidade: " + Localidade +
                   "\nUF: " + Uf;
        }
    }
}

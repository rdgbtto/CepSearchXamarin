using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CepSearch.Servico.Modelo;
using CepSearch.Servico;

namespace CepSearch
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Botao.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs args)
        {
            string cep = Cep.Text.Trim();
            if (isValidCep(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEndereco(cep);
                    if (end != null)
                    {
                        Resultado.Text = end.ToString();
                    }
                    else
                    {
                        DisplayAlert("ERRO", "CEP inválido! Endereço não encontrado para o CEP informado: " + cep, "OK");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
            }
        }

        private bool isValidCep(string cep)
        {
            bool valid = true;
            int novoCep = 0;
            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                valid = false;
            }
            if (!int.TryParse(cep, out novoCep))
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve ser composto apanas por números.", "OK");
                valid = false;
            }

            return valid;
        }
    }
}

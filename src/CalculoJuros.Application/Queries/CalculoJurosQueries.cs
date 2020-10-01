using CalculoJuros.Application.Extensions;
using CalculoJuros.Application.Interfaces.Queries;
using CalculoJuros.Application.Requests;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculoJuros.Application.Queries
{
    public class CalculoJurosQueries : ICalculoJurosQueries
    {
        private readonly AppSettings _appSettings;

        public CalculoJurosQueries(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<string> CalcularJuros(CalculoJurosRequest calculoJurosRequest)
        {
            var taxa = RetornarTaxa();

            for (int meses = 0; meses < calculoJurosRequest.Meses; meses++)
            {
                calculoJurosRequest.ValorInicial *= (1 + taxa);
            }

            return calculoJurosRequest.ValorInicial.ToString("F");
        }

        private double RetornarTaxa()
        {
            using (var client = new HttpClient())
            {
                string baseUrl = _appSettings.UrlTaxasJuros + "taxajuros";
                var response = client.GetAsync(baseUrl).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    return Convert.ToDouble(responseContent.ReadAsStringAsync().GetAwaiter().GetResult()) / 100;
                }
            }

            return 0;
        } 
    }
}

using CalculoJuros.Application.Requests;

namespace CalculoJuros.Tests.Builders.Requests
{
    public class CalculoJurosRequestBuilder : CalculoJurosRequest
    {
        private static CalculoJurosRequest instance;

        public CalculoJurosRequestBuilder()
        {
            instance = new CalculoJurosRequest
            {
                Meses = 5,
                ValorInicial = 100
            };
        }

        public CalculoJurosRequest Build()
        {
            return instance;
        }
    }
}

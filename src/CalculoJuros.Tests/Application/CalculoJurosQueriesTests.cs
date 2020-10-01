using CalculoJuros.Application.Queries;
using CalculoJuros.Tests.Builders.Requests;
using Moq.AutoMock;
using System;
using Xunit;

namespace CalculoJuros.Tests.Application
{
    public class CalculoJurosQueriesTests
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private readonly CalculoJurosQueries _calculoJurosQueries;

        public CalculoJurosQueriesTests()
        {
            _calculoJurosQueries = _mocker.CreateInstance<CalculoJurosQueries>();
        }

        [Fact(DisplayName = "CalcularJuros")]
        [TraitAttribute("CalcularJuros", "CalculoJurosQueries")]
        public void CalcularJuros_ShouldBeTrue()
        {
            bool sucesso;

            try
            {
                var request = new CalculoJurosRequestBuilder();

                var x = _calculoJurosQueries.CalcularJuros(request);

                sucesso = true;
            }
            catch (Exception e)
            {
                sucesso = false;
            }

            Assert.True(sucesso);
        }
    }
}

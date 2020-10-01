using System.Threading.Tasks;
using CalculoJuros.Application.Interfaces.Queries;
using CalculoJuros.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CalculoJuros.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculaJurosController : Controller
    {
        private readonly ICalculoJurosQueries _calculoJurosQueries;

        public CalculaJurosController(ICalculoJurosQueries calculoJurosQueries)
        {
            _calculoJurosQueries = calculoJurosQueries;
        }

        /// <summary>
        /// Calcular juros
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery] CalculoJurosRequest calculoJurosRequest)
        {
            return Ok(await _calculoJurosQueries.CalcularJuros(calculoJurosRequest));
        }
    }
}

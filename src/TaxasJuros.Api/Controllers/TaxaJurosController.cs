using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaxasJuros.Api.Extensions;

namespace TaxasJuros.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxaJurosController : Controller
    {
        private readonly AppSettings _appSettings;
        
        public TaxaJurosController(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        /// <summary>
        /// Retorna a taxa de juros
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(200, Type = typeof(double))]
        public async Task<ActionResult> Get()
        {
            return Ok(_appSettings.TaxaJuros);
        }
    }
}

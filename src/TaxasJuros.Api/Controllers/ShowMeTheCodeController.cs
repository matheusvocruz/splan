using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TaxasJuros.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : Controller
    {
        /// <summary>
        /// Retorna a url do repositório do github
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<ActionResult> Get()
        {
            return Ok("https://github.com/matheusvocruz/splan");
        }
    }
}

using CalculoJuros.Application.Requests;
using System.Threading.Tasks;

namespace CalculoJuros.Application.Interfaces.Queries
{
    public interface ICalculoJurosQueries
    {
        Task<string> CalcularJuros(CalculoJurosRequest calculoJurosRequest);
    }
}

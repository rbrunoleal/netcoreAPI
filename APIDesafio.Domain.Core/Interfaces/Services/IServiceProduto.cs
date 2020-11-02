using APIDesafio.Domain.Entity;
using System.Threading.Tasks;

namespace APIDesafio.Domain.Core.Interfaces.Services
{
    public interface IServiceProduto : IServiceBase<Produto>
    {
        Task<Produto> GetByIdIncludeCategoria(int id);
    }
}

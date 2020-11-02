using APIDesafio.Domain.Entity;
using System.Threading.Tasks;

namespace APIDesafio.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryProduto : IRepositoryBase<Produto>
    {
        Task<Produto> GetByIdIncludeCategoria(int id);
    }
}

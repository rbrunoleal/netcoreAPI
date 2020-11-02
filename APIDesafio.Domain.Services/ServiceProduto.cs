using APIDesafio.Domain.Core.Interfaces.Repositorys;
using APIDesafio.Domain.Core.Interfaces.Services;
using APIDesafio.Domain.Entity;
using System.Threading.Tasks;

namespace APIDesafio.Domain.Services
{
    public class ServiceProduto : ServiceBase<Produto>, IServiceProduto
    {
        private readonly IRepositoryProduto repositoryProduto;

        public ServiceProduto(IRepositoryProduto repositoryProduto) : base(repositoryProduto)
        {
            this.repositoryProduto = repositoryProduto;
        }

        public async Task<Produto> GetByIdIncludeCategoria(int id)
        {
            return await repositoryProduto.GetByIdIncludeCategoria(id);
        }
    }
}

using APIDesafio.Domain.Core.Interfaces.Repositorys;
using APIDesafio.Domain.Core.Interfaces.Services;
using APIDesafio.Domain.Entity;

namespace APIDesafio.Domain.Services
{
    public class ServiceCategoria : ServiceBase<Categoria>, IServiceCategoria
    {
        private readonly IRepositoryCategoria repositoryCategoria;

        public ServiceCategoria(IRepositoryCategoria repositoryCategoria) : base(repositoryCategoria)
        {
            this.repositoryCategoria = repositoryCategoria;
        }
    }
}

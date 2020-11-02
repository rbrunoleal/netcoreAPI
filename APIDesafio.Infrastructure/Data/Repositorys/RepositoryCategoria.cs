using APIDesafio.Domain.Core.Interfaces.Repositorys;
using APIDesafio.Domain.Entity;

namespace APIDesafio.Infrastructure.Data.Repositorys
{
    public class RepositoryCategoria : RepositoryBase<Categoria>, IRepositoryCategoria
    {
        private readonly Context sqlContext;

        public RepositoryCategoria(Context sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}

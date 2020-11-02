using APIDesafio.Domain.Core.Interfaces.Repositorys;
using APIDesafio.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace APIDesafio.Infrastructure.Data.Repositorys
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        private readonly Context sqlContext;

        public RepositoryProduto(Context sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
        public async Task<Produto> GetByIdIncludeCategoria(int id)
        {
            return await sqlContext.Produtos.Include("Categoria").FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

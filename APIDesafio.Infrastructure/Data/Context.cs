using APIDesafio.Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIDesafio.Infrastructure.Data
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public Context(DbContextOptions<Context> options = null) : base(options)
        {           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>().HasData(new Categoria {Id = 1, Descricao = "Informática"});
            modelBuilder.Entity<Categoria>().HasData(new Categoria {Id = 2, Descricao = "Eletrônicos"});
            modelBuilder.Entity<Categoria>().HasData(new Categoria {Id = 3, Descricao = "Móveis"});
            modelBuilder.Entity<Produto>().HasData(new Produto 
            {
                Id = 1,
                Valor = 1000,
                Quantidade = 10,
                CategoriaId = 1,
                Descricao = "Notebook"
            });
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 2,
                Valor = 1000,
                Quantidade = 12,
                CategoriaId = 1,
                Descricao = "Computador"
            });
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 3,
                Valor = 1500,
                Quantidade = 10,
                CategoriaId = 3,
                Descricao = "Sofá"
            });
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 4,
                Valor = 1500,
                Quantidade = 10,
                CategoriaId = 2,
                Descricao = "Playstation"
            });
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 5,
                Valor = 1500,
                Quantidade = 10,
                CategoriaId = 2,
                Descricao = "Celular"
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQL2017; Database=APIDesafio; User Id=admin; Password=admin");
        }
    }
}

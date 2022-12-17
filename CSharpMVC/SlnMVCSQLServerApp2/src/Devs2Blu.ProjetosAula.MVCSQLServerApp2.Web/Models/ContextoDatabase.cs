using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models
{
    public class ContextoDatabase : DbContext
    {
        public ContextoDatabase(DbContextOptions<ContextoDatabase> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento de Relacionamento
            modelBuilder.Entity<Produto>()
                .HasOne(produto => produto.Categoria)
                .WithMany(categoria => categoria.Produtos)
                .HasForeignKey(produto => produto.CategoriaId);
            
            modelBuilder.Entity<Produto>()
                .HasOne(produto => produto.Marca)
                .WithMany(marca => marca.Produtos)
                .HasForeignKey(produto => produto.MarcaId);



            // Seed
            modelBuilder.Entity<Categoria>()
                .HasData(
                new { Id = 1, Nome = "Alimentos Não Perecíveis"},
                new { Id = 2, Nome = "Laticínios"},
                new { Id = 3, Nome = "Limpeza"},
                new { Id = 4, Nome = "Bebidas Não Alcoólicas"}
                );

            modelBuilder.Entity<Produto>()
                .HasData(
                new { Id = 1, Nome = "Arroz Tio Urbano", Preco = 10.00, Quantidade = 5, CategoriaId = 1 },
                new { Id = 2, Nome = "Feijão Tio Urbano", Preco = 10.00, Quantidade = 5, CategoriaId = 1 },
                new { Id = 3, Nome = "Queijo", Preco = 20.00, Quantidade = 5, CategoriaId = 2 },
                new { Id = 4, Nome = "Iogurte", Preco = 20.00, Quantidade = 5, CategoriaId = 2 },
                new { Id = 5, Nome = "Sabão Líquido", Preco = 30.00, Quantidade = 5, CategoriaId = 3 },
                new { Id = 6, Nome = "Multiuso", Preco = 30.00, Quantidade = 5, CategoriaId = 3 },
                new { Id = 7, Nome = "Suco de Laranja 1L", Preco = 40.00, Quantidade = 5, CategoriaId = 4 },
                new { Id = 8, Nome = "Coca-cola 2L", Preco = 40.00, Quantidade = 5, CategoriaId = 4 }
                );

            base.OnModelCreating(modelBuilder);
        }

        #region DbSets
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }

        #endregion
    }
}

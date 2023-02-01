using Microsoft.EntityFrameworkCore;
using RevisaoProjetoNoticias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisaoProjetoNoticias.Infra.Data.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options)
            :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed
            modelBuilder.Entity<Category>()
                .HasData(
                new { Id = 1, Name = "Destaque" },
                new { Id = 2, Name = "Programação" },
                new { Id = 3, Name = "Jogos" },
                new { Id = 4, Name = "Negócios" }
                );
        }

        #region DBSets<Tables>

        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
        #endregion
    }
}

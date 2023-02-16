using Devs2Blu.PrimeiraAPIASPNetCore.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devs2Blu.PrimeiraAPIASPNetCore.API.Models.Data
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasData(
                new {Id = 1, Name = "Ana Silva", Contact1 = "47988556622", Email = "anasilva@email.com"},
                new {Id = 2, Name = "Arnaldo Silva", Contact1 = "47988554422", Email = "arnaldosilva@email.com"},
                new {Id = 3, Name = "Carlos Silva", Contact1 = "47988335599", Email = "carlossilva@email.com"}
                );
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}

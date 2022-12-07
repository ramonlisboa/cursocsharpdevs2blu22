using Devs2Blu.ProjetosAula.MVCSQL.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devs2Blu.ProjetosAula.MVCSQL.Web.Models
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {

        }

        #region DbSets

        public DbSet<Filme> Filme { get; set; }

        #endregion
    }
}

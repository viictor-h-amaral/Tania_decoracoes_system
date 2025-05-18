using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TaniaDecoracoes.Entities.Data.Contexto
{
    public class TaniaDecoracoesDbContext : DbContext
    {
        public TaniaDecoracoesDbContext()
        {
        }

        public TaniaDecoracoesDbContext(DbContextOptions<TaniaDecoracoesDbContext> options) : base(options)
        {
        }

        #region TABELAS

        //public DbSet<Estados> Estados { get; set; }

        #endregion TABELAS

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = AppSettings.Configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
    }
}

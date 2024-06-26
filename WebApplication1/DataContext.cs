using Entidades;
using Microsoft.EntityFrameworkCore;


namespace TP_MS_Evento
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<EntidadeEvento> Evento { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntidadeEvento>().HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}

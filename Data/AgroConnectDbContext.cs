using AgroConnect.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroConnect.Data
{
    public class AgroConnectDbContext: DbContext
    {
        public AgroConnectDbContext(DbContextOptions dbContextOptions ): base(dbContextOptions) { }
        public virtual DbSet<Gado> gados { get; set; }
        public virtual DbSet<Usuario> usuarios { get; set; }
        public virtual DbSet<Plantacao> plantacoes { get; set; }
        public virtual DbSet<GadoHistorico> gadoHistoricos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gado>()
                .HasOne(g => g.Usuario)
                .WithMany(u => u.Gados)
                .HasForeignKey(g => g.UsuarioId);

            modelBuilder.Entity<Plantacao>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Plantacoes)
                .HasForeignKey(p => p.UsuarioId);

            modelBuilder.Entity<Gado>()
                .HasOne(g => g.Historico)
                .WithOne();
        }
    }
}

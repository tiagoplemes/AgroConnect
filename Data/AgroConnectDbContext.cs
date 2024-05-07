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
    }
}

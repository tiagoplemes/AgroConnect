using AgroConnect.BackEnd;
using Microsoft.EntityFrameworkCore;

namespace AgroConnect.Data
{
    public class AgroConnectDbContext: DbContext
    {
        protected string Configuration;
        public DbSet<Gado> gados;
        public DbSet<Usuario> usuarios;
        public DbSet<Plantacao> plantacoes;
        public DbSet<GadoHistorico> gadoHistoricos;

        //public AppContext(DbContextOptions<AppContext> options)
        //: base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=localhost;Database=AgroConnect;Port=5432;User Id=postgres;Password=admin;");


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    IConfigurationRoot config = new ConfigurationBuilder()
        //       .SetBasePath(Directory.GetCurrentDirectory())
        //       .AddJsonFile("appsettings.json")
        //       .Build();
        //    string connString = config.GetConnectionString("AgroConnect");
        //    optionsBuilder.UseNpgsql(connString);
        //}

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllers();

        //    IConfigurationRoot config = new ConfigurationBuilder()
        //       .SetBasePath(Directory.GetCurrentDirectory())
        //       .AddJsonFile("appsettings.json")
        //       .Build();
        //    string? connString = config.GetConnectionString("AgroConnect");

        //    services.AddDbContext<AppContext>(
        //        options => options.UseNpgsql(connString));
        //}
    }
}

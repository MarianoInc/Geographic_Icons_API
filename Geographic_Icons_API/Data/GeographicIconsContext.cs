using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Geographic_Icons_API.Data
{
    public class GeographicIconsContext : DbContext
    {
        //Inyecto dependencia de  tipo IConfiguration para tomar la cadena de conexión de appsettings.json.
        public IConfiguration Configuration { get; }
        
        //Envio opciones adicionales a la clase DbContext a través de options e inicializo Configuration.
        public GeographicIconsContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("GeographicIconsConnectionString"));
        }
        public DbSet<GeographicIcon> GeographicIcons { get; set; }
        public DbSet<CityCountry> CitiesCountries { get; set; }
        public DbSet<Continent> Continents { get; set; }
    }
}

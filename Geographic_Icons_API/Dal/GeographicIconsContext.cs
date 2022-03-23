using Microsoft.EntityFrameworkCore;

namespace Geographic_Icons_API.Data
{
    public class GeographicIconsContext : DbContext
    {
        //Envio opciones adicionales a la clase DbContext a través de options e inicializo Configuration.
        public GeographicIconsContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R262SOH\\SQLEXPRESS;Database=GeographicIconsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbSet<GeographicIcon> GeographicIcons { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Continent> Continents { get; set; }
    }
}

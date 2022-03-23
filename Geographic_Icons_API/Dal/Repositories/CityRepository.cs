using Geographic_Icons_API.Data;
using Geographic_Icons_API.Interfaces;

namespace Geographic_Icons_API.Repositories
{
    public class CityRepository : BaseRepository<City, GeographicIconsContext>, ICityRepository
    {
        public CityRepository(GeographicIconsContext context) : base(context)
        {

        }
    }
}

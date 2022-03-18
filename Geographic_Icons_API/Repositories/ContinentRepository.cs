using Geographic_Icons_API.Data;
using Geographic_Icons_API.Interfaces;

namespace Geographic_Icons_API.Repositories
{
    public class ContinentRepository : BaseRepository<Continent, GeographicIconsContext>, IContinentRepository
    {
        public ContinentRepository(GeographicIconsContext context) : base(context)
        {

        }
    }
}

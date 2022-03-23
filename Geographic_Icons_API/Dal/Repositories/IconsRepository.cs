using Geographic_Icons_API.Data;
using Geographic_Icons_API.Interfaces;

namespace Geographic_Icons_API.Repositories
{
    public class IconsRepository : BaseRepository<GeographicIcon, GeographicIconsContext>, IIconsRepository
    {
        public IconsRepository(GeographicIconsContext context) : base(context)
        {

        }
    }
}

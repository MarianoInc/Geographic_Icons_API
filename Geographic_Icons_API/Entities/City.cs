using System.Collections.Generic;

namespace Geographic_Icons_API
{
    public class City
    {
        public int CityId { get; set; }
        public string CityPicture { get; set; }
        public string CityName { get; set; }
        public ulong Population { get; set; }
        public ulong Area { get; set; }

        public int ContinentId { get; set; }
        public Continent Continent { get; set; }


        public ICollection<GeographicIcon> GeographicIcon { get; set; }
    }
}

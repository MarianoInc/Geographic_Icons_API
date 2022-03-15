using System.Collections.Generic;

namespace Geographic_Icons_API
{
    public class CityCountry
    {
        public int CityCountryId { get; set; }
        public byte[] CityCountryPicture { get; set; }
        public string CityCountryName { get; set; }
        public ulong Population { get; set; }
        public ulong TotalLandArea { get; set; }
        public Continent Continent { get; set; }


        public ICollection<GeographicIcon> GeographicIcon { get; set; }
    }
}

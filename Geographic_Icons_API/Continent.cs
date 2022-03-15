using System.Collections.Generic;

namespace Geographic_Icons_API
{
    public class Continent
    {
        public int ContinentId { get; set; }
        public byte[] ContinentPicture { get; set; }
        public string ContinentName { get; set; }
        public ICollection<CityCountry> Cities_Countries { get; set; }
    }
}

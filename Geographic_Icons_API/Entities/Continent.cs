using System.Collections.Generic;

namespace Geographic_Icons_API
{
    public class Continent
    {
        public int ContinentId { get; set; }
        public string ContinentPicture { get; set; }
        public string ContinentDenomination { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}

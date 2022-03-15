using System;
using System.Collections.Generic;

namespace Geographic_Icons_API
{
    public class GeographicIcon
    {
        public int GeographicIconId { get; set; }
        public byte[] GeographicIconPicture { get; set; }
        public DateTime FinishingDate { get; set; }
        public int Height { get; set; }
        public string History { get; set; }
        public ICollection<CityCountry> CitiesCountries { get; set; }
    }
}

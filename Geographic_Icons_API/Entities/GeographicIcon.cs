using System;
using System.Collections.Generic;

namespace Geographic_Icons_API
{
    public class GeographicIcon
    {
        public int GeographicIconId { get; set; }
        public string GeographicIconDenomination { get; set; }
        public string GeographicIconPicture { get; set; }
        public DateTime CreationDate { get; set; }
        public int Height { get; set; }
        public string History { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}

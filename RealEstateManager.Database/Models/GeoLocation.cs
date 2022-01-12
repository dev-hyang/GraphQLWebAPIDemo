using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManager.Database.Models
{
    public class GeoLocation
    {
        public int Id { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
    }
}

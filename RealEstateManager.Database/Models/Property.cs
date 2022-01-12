using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManager.Database.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public Address PropertyAddress { get; set; }
        public decimal Value { get; set; }
        public string Owner { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManager.Database.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public GeoLocation Geo { get; set; }
    }
}

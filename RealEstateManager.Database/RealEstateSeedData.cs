using RealEstateManager.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateManager.Database
{
    public static class RealEstateSeedData
    {
        public static void EnsureSeedData(this RealEstateContext db)
        {
            if (!db.Properties.Any() || !db.Payments.Any())
            {
                var geo1 = new GeoLocation
                {
                    latitude = 43.12M,
                    longitude = -44.17M
                };
                var address1 = new Address
                {
                    Address1 = "102 Subeen Street",
                    City = "Chicago",
                    State = "IL",
                    ZipCode = "60607",
                    Geo = geo1
                };

                var geo2 = new GeoLocation
                {
                    latitude = 43.12M,
                    longitude = -44.17M
                };
                var address2 = new Address
                {
                    Address1 = "102 Subeen Street",
                    City = "Chicago",
                    State = "IL",
                    ZipCode = "60607",
                    Geo = geo2
                };

                var geo3 = new GeoLocation
                {
                    latitude = 45.12M,
                    longitude = -44.17M
                };
                var address3 = new Address
                {
                    Address1 = "182 Subeen Street",
                    City = "Chicago",
                    State = "IL",
                    ZipCode = "60607",
                    Geo = geo3
                };

                var geo4 = new GeoLocation
                {
                    latitude = 46.12M,
                    longitude = -44.17M
                };
                var address4 = new Address
                {
                    Address1 = "192 Subeen Street",
                    City = "Chicago",
                    State = "IL",
                    ZipCode = "60607",
                    Geo = geo4
                };

                db.GeoLocations.Add(geo1);
                db.GeoLocations.Add(geo2);
                db.GeoLocations.Add(geo3);
                db.GeoLocations.Add(geo4);

                db.Addresses.Add(address1);
                db.Addresses.Add(address2);
                db.Addresses.Add(address3);
                db.Addresses.Add(address4);

                var property1 = new Property
                {
                    Name = "Wings BBQ",
                    Owner = "Yang",
                    Value = 1000M,
                    PropertyAddress = address1
                };
                var property2 = new Property
                {
                    Name = "Wendy's",
                    Owner = "Scott",
                    Value = 3000M,
                    PropertyAddress = address2
                };
                var property3 = new Property
                {
                    Name = "Young's Dentist Clinic",
                    Owner = "Waan",
                    Value = 4000M,
                    PropertyAddress = address3
                };
                var property4 = new Property
                {
                    Name = "Fitness & SPA",
                    Owner = "Swift",
                    Value = 7000M,
                    PropertyAddress = address4
                };
                db.Properties.Add(property1);
                db.Properties.Add(property2);
                db.Properties.Add(property3);
                db.Properties.Add(property4);
                db.SaveChanges();

                var payment1 = new Payment
                {
                    DateCreated = DateTime.Parse("01/01/2021 09:32"),
                    DateOverdue = DateTime.Parse("01/31/2021 09:32"),
                    Value = 129000.00M,
                    IsPaid = true,
                    PropertyId = property1.Id
                };
                var payment2 = new Payment
                {
                    DateCreated = DateTime.Parse("02/01/2021 09:32"),
                    DateOverdue = DateTime.Parse("03/31/2021 09:32"),
                    Value = 390000.00M,
                    IsPaid = true,
                    PropertyId = property2.Id
                };
                var payment3 = new Payment
                {
                    DateCreated = DateTime.Parse("05/01/2021 09:32"),
                    DateOverdue = DateTime.Parse("05/31/2021 09:32"),
                    Value = 43000.00M,
                    IsPaid = true,
                    PropertyId = property2.Id
                };
                var payment4 = new Payment
                {
                    DateCreated = DateTime.Parse("07/01/2021 09:32"),
                    DateOverdue = DateTime.Parse("07/12/2021 09:32"),
                    Value = 73000.00M,
                    IsPaid = true,
                    PropertyId = property4.Id
                };
                db.Payments.Add(payment1);
                db.Payments.Add(payment2);
                db.Payments.Add(payment3);
                db.Payments.Add(payment4);
                db.SaveChanges();
            }
        }
    }
}

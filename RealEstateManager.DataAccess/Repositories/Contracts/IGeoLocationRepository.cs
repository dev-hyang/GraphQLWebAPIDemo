using RealEstateManager.Database.Models;
using System;
using System.Collections.Generic;

namespace RealEstateManager.DataAccess.Repositories.Contracts
{
    public interface IGeoLocationRepository
    {
        IEnumerable<Property> GetAll();
    }
}

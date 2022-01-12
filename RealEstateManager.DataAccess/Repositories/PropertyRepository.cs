using RealEstateManager.DataAccess.Repositories.Contracts;
using RealEstateManager.Database;
using RealEstateManager.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateManager.DataAccess.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly RealEstateContext _dbContext;

        public PropertyRepository(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Property Add(Property property)
        {
            _dbContext.Properties.Add(property);
            _dbContext.SaveChanges();
            return property;
        }

        public IEnumerable<Property> GetAll()
        {
            return _dbContext.Properties.Where(x => 1 == 1);
        }

        public Property GetById(int id)
        {
            return _dbContext.Properties.FirstOrDefault(x => x.Id == id);
        }
    }
}

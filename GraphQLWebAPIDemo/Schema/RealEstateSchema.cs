using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQLWebAPIDemo.Queries;

namespace GraphQLWebAPIDemo.Schema
{
    public class RealEstateSchema : GraphQL.Types.Schema
    {
        public RealEstateSchema(PropertyQuery query, 
            PropertyMutation mutation,
            IServiceProvider serviceProvider)
            :base(serviceProvider)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}

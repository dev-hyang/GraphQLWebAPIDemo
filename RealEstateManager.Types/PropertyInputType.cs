using GraphQL.Types;
using RealEstateManager.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManager.Types
{
    public class PropertyInputType : InputObjectGraphType
    {
        public PropertyInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<IntGraphType>("value");
            Field<StringGraphType>("owner");
        }

        //public override object ParseDictionary(IDictionary<string, object> value)
        //{
        //    return new Property
        //    {
        //        Name = ((string)value["name"]).ToUpper(),
        //        Owner = (string)value["owner"],
        //        Value = (int)value["value"],
        //        Id = default,
        //    };
        //}
    }
}

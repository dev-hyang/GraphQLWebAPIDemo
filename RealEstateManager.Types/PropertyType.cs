using GraphQL;
using GraphQL.Types;
using RealEstateManager.DataAccess.Repositories.Contracts;
using RealEstateManager.Database.Models;
using System;

namespace RealEstateManager.Types
{
    public class PropertyType : ObjectGraphType<Property>
    {
        public PropertyType(IPaymentRepository paymentRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Value);
            Field(x => x.Owner);
            //Field<ListGraphType<PaymentType>>("payments",
            //    resolve : context => paymentRepository.GetAllForProperty(context.Source.Id));
            Field<ListGraphType<PaymentType>>("payments",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "last" }),
                resolve: context =>
                {
                    //dynamic lastItemsFilter;
                    var lastItemsFilter = context.GetArgument<int?>("last");
                    return lastItemsFilter.HasValue
                        ? paymentRepository.GetAllForProperty(context.Source.Id, lastItemsFilter.Value)
                        : paymentRepository.GetAllForProperty(context.Source.Id);
                });
            //Field(x => x.PropertyAddress);
            //Field(x => x.Payments);
        }
    }
}

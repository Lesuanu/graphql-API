using GloryFarm.Infrastructure;
using GloryFarm.Models;

namespace GloryFarm.API.GraphQL.FarmAddress_types
{
    public class FarmAddressType : ObjectType<FarmAddress>
    {
        protected override void Configure(IObjectTypeDescriptor<FarmAddress> descriptor)
        {
            descriptor.Description("repreents farmers general info");

            descriptor
                .Field(p => p.City).Ignore();

            descriptor
                .Field(p => p.FarmInfo)
                .ResolveWith<Resolvers>(p => p.GetFarmInfo(default!, default!))
                .UseDbContext<GloryFarmContext>()
                .Description("this is the available farm address for farms");

            descriptor.Field(p => p.FarmInfo);
        }

        private class Resolvers
        {
            public Farm GetFarmInfo(FarmAddress farmAddress, [ScopedService] GloryFarmContext context)
            {               
                var result = context.GloryFarms.FirstOrDefault(p => p.Id == farmAddress.FarmInfoId);
                return result;
            }

        }
    }
}

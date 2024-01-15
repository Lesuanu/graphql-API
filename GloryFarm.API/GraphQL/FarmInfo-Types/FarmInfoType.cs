using GloryFarm.Infrastructure;
using GloryFarm.Models;

namespace GloryFarm.API.GraphQL.FarmInfo_Types
{
    public class FarmInfoType : ObjectType<Farm>
    {
        protected override void Configure(IObjectTypeDescriptor<Farm> descriptor)
        {
            descriptor.Description("repreents farmers general info");

            descriptor
                .Field(p => p.FarmIdNumber).Ignore();

            descriptor
                .Field(p => p.FarmAddresses)  
                .ResolveWith<Resolvers>(x => x.GetAddress(default!, default!))
                .UseDbContext<GloryFarmContext>()
                .Description("this is the available farm address for farms");
        }     
    }

    public class Resolvers
    {
        public IQueryable<FarmAddress> GetAddress(Farm farm, [ScopedService] GloryFarmContext? context)
        {
            return context.Addresses.Where(x => x.Id == farm.Id);
        }
    }
}

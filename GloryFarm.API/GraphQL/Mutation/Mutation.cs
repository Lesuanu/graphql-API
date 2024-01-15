using GloryFarm.API.GraphQL.FarmAddress_types;
using GloryFarm.Infrastructure;
using GloryFarm.Models;
using HotChocolate.Subscriptions;

namespace GloryFarm.API.GraphQL.Mutation
{
    public class Mutation
    { 
        [UseDbContext(typeof(GloryFarmContext))]
        public async Task<AddFarmPayload> AddFarmAsync(AddFarmInput input,
            [ScopedService] GloryFarmContext context, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var farm = new Farm
            {
                FarmName = input.name
            };

            context.GloryFarms.AddAsync(farm);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnFarmAdded), farm, cancellationToken);

            return new AddFarmPayload(farm);
        }
    }
}

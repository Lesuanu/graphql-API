using GloryFarm.Models;

namespace GloryFarm.API.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Farm OnFarmAdded([EventMessage] Farm farm)
        {
            return farm;
        }
    }
}

using GloryFarm.Infrastructure;
using GloryFarm.Models;
using System.Linq;


namespace GloryFarm.API.GraphQL
{
    public class Query
    {

        //  public IQueryable<FarmInfo> GetfarmInfo([Service] GloryFarmContext context)
        // {

        //    return context.GloryFarms;
        // }

        //[UseDbContext(typeof(GloryFarmContext))] //to perform multiple query on farm
        //public IQueryable<FarmInfo> GetfarmInfo([ScopedService] GloryFarmContext context)
        //{

        //    return context.GloryFarms;
        //}

        [UseDbContext(typeof(GloryFarmContext))]
       // [UseProjection] is not used with resolvers
        [UseFiltering]
        [UseSorting]
        public IQueryable<Farm> GetfarmInfo([ScopedService] GloryFarmContext context)
        {

            return context.GloryFarms;
        }

        [UseDbContext(typeof(GloryFarmContext))]
      //  [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<FarmAddress> GetFarmAddress([ScopedService] GloryFarmContext context)
        {
            return context.Addresses;
        }

        [UseDbContext(typeof(GloryFarmContext))]
      //  [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<FarmEmployees> GetFarmEmployee([ScopedService] GloryFarmContext context)
        {
            return context.Employees;
        }

    }
}

using GloryFarm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloryFarm.Infrastructure.EntityConfiguration
{
    public class FarmInfoTypeConfigurationn : IEntityTypeConfiguration<Farm>
    {
        //model configuration
        public void Configure(EntityTypeBuilder<Farm> builder)
        {
            builder
                .HasMany(p => p.FarmAddresses)
                .WithOne(p => p.FarmInfo)
               .HasForeignKey(p => p.FarmInfoId);

            builder
                .HasMany(p => p.FarmEmployees)
                .WithOne(p => p.Farm)
                .HasForeignKey(o => o.FarmId);
        }
    }
}

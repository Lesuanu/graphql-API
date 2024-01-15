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
    internal class FarmAddressTypeConfiguration : IEntityTypeConfiguration<FarmAddress>
    {
        public void Configure(EntityTypeBuilder<FarmAddress> builder)
        {
             builder
                .HasOne(p => p.FarmInfo)
                .WithMany(p => p.FarmAddresses)
                .HasForeignKey(p => p.FarmInfoId);
        }
    }
}

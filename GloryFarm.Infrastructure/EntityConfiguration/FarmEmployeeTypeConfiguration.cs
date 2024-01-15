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
    public class FarmEmployeeTypeConfiguration : IEntityTypeConfiguration<FarmEmployees>
    {
        public void Configure(EntityTypeBuilder<FarmEmployees> builder)
        {
            builder
                .HasOne(o => o.Farm)
                .WithMany(o => o.FarmEmployees)
                .HasForeignKey(o => o.FarmId);
        }
    }
}

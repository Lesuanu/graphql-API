using GloryFarm.Infrastructure.EntityConfiguration;
using GloryFarm.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloryFarm.Infrastructure
{
    public class GloryFarmContext : DbContext
    {
        public GloryFarmContext(DbContextOptions<GloryFarmContext> options) : base(options)
        {
           
        }

        public DbSet<Farm>? GloryFarms { get; set; }
        public DbSet<FarmAddress>? Addresses { get; set; }
        public DbSet<FarmEmployees>? Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<FarmInfo>()
            //    .HasMany(p => p.FarmAddresses)
            //    .WithOne(p => p.FarmInfo)
            //    .HasForeignKey(p => p.FarmInfoId);

            //modelBuilder.Entity<FarmAddress>()
            //    .HasOne(p => p.FarmInfo)
            //    .WithMany(p => p.FarmAddresses)
            //    .HasForeignKey(p => p.FarmInfoId);

            modelBuilder.ApplyConfiguration(new FarmInfoTypeConfigurationn());
            modelBuilder.ApplyConfiguration(new FarmAddressTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FarmEmployeeTypeConfiguration());
        }
    }
}

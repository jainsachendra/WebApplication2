using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Persistence
{
    public class VegaDbContext:DbContext
    {
        public DbSet<Make> makes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public VegaDbContext(DbContextOptions<VegaDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>().HasKey(vf => new { vf.VehicleId, vf.FeatureId });
        }
       

    }
}

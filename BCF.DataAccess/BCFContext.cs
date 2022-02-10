using BCF.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BCF.DataAccess
{
    public class BCFContext: DbContext
    {
        public BCFContext(DbContextOptions options) : base(options) { }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Garage> Garages { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Garage>(entity =>
            {
                entity.HasMany(e => e.Vehicles)
                .WithOne(e => e.Garage)
                .HasForeignKey(e => e.GarageId);
            });
            builder.Entity<Warehouse>(entity =>
            {
                entity.HasOne(e => e.Cars)
                .WithOne(e => e.Warehouse)
                .HasForeignKey<Garage>(e => e.WarehouseId);

                entity.HasOne(e => e.Location)
                .WithOne(e => e.Warehouse)
                .HasForeignKey<Location>(e => e.WarehouseId);
            });
        }
    }
}

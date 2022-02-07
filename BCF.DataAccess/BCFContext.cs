using BCF.Model.Entities;
using Microsoft.EntityFrameworkCore;

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
            builder.Entity<User>(entity =>
            {
                entity.HasMany(e => e.Flats)
                .WithOne(e => e.Owner)
                .HasForeignKey(e => e.OwnerId);

                entity.HasMany(e => e.Rentals)
                .WithOne(e => e.Tenant)
                .HasForeignKey(e => e.TenantId);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            builder.Entity<Flat>(entity =>
            {
                entity.HasMany(e => e.Facilities)
                .WithOne(e => e.Flat)
                .HasForeignKey(e => e.FlatId);

                entity.HasMany(e => e.Rentals)
                .WithOne(e => e.Flat)
                .HasForeignKey(e => e.FlatId);

                entity.HasMany(e => e.Photos)
                .WithOne(e => e.Flat)
                .HasForeignKey(e => e.FlatId);
            });
        }
    }
}

using Hotel_Listing.api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Listing.api.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions<HotelListingDbContext> options) : base(options)
        {
            
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Jamaica",
                    ShortName = "JM",
                },
                new Country
                {
                    Id = 2,
                    Name = "Nigeria",
                    ShortName = "NG",
                }, new Country
                {
                    Id = 3,
                    Name = "Egypt",
                    ShortName = "EG",
                }, new Country
                {
                    Id = 4,
                    Name = "Cameron",
                    ShortName = "CM",
                }
            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "San Hoeshi francuas",
                    Address = "San teigo",
                    CountryId = 1,
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Confideration Le Chalee",
                    Address = "Chile",
                    CountryId = 3,
                    Rating = 4.2
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Lumberato Es Satao",
                    Address = "Spain",
                    CountryId = 2,
                    Rating = 4
                }
            );
        }
    }
}

using Hotel_Listing.api.Data;
using Hotel_Listing.api.Models;
using Hotel_Listing.api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Listing.api.Services.Repository
{
    public class CountryRepo : GenericRepository<Country>, ICountryRepo
    {
        private readonly HotelListingDbContext _context;

        public CountryRepo(HotelListingDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries.Include(d => d.Hotels).FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}

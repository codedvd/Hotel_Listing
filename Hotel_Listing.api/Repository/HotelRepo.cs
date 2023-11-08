using Hotel_Listing.api.Contracts;
using Hotel_Listing.api.Data;
using Hotel_Listing.api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Listing.api.Repository
{
    public class HotelRepo : GenericRepository<Hotel>, IHotelRepo
    {
        private readonly HotelListingDbContext _context;
        public HotelRepo(HotelListingDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

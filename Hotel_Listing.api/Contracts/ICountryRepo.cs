using Hotel_Listing.api.Models;

namespace Hotel_Listing.api.Contracts
{
    public interface ICountryRepo : IGenericRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }
}

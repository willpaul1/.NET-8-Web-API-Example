using BaseLibrary.DTOs;
using BaseLibrary.Helpers;
namespace ServerLibrary.Repositories.Contracts
{
    public interface IVenues
    {
        Task<List<VenueWithEventsDto>> GetAllVenuesWithEvents(QueryObject query);
    }
}
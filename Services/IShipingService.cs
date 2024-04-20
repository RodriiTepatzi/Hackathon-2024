using Hackathon_2024_API.Models;
using Hackathon_2024_API.Schemas;

namespace Hackathon_2024_API.Services
{
    public interface IShipingService
    {

        Task<Shiping?> CreateShipingAsync(Shiping shiping);

        Task<Shiping?> GetShipingByIdAsync(string id);

        Task <List<Shiping>> GetShipingsByCarrier(string idCarrier);


    }
}

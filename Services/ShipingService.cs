using Hackathon_2024_API.Data;
using Hackathon_2024_API.Models;
using Hackathon_2024_API.Schemas;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_2024_API.Services
{
    public class ShipingService:IShipingService
    {
        private readonly AppDbContext _context;
        

        public ShipingService(AppDbContext context)
        {
            _context = context;
        }

        

        public async Task<Shiping?> CreateShipingAsync(Shiping shiping)
        {

            var entity = _context.Entry(shiping);
            var result = entity.Entity;

            entity.State = EntityState.Added;

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<Shiping?> GetShipingByIdAsync(string id) {



            try
            {

                var result = await _context.Shipings.SingleOrDefaultAsync(i => i.Id == id);

                if (result == null) return null;

                var entity = _context.Entry(result);

                if (entity.State == EntityState.Unchanged)
                {
                    return entity.Entity;
                }
                else
                {
                    return entity.Entity;
                }
            }
            catch (InvalidOperationException)
            {
                return null;
            }

        }

        public async Task<List<Shiping>> GetShipingsByCarrier(string idCarrier)
        {

            var result = await _context.Shipings.Where(s => s.IdCarrier == idCarrier).ToListAsync();

            return result;
        }

    }
}

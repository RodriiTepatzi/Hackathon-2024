using Hackathon_2024_API.Data;
using Hackathon_2024_API.Models;
using Hackathon_2024_API.Schemas;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_2024_API.Services
{
    public class PackageService:IPackageService
    {
        private readonly AppDbContext _context;


        public PackageService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Package> CreatePackageAsync(Package package) {

            var entity = _context.Entry(package);
            var result = entity.Entity;
            entity.State = EntityState.Added;

            await _context.SaveChangesAsync();

            return result;

        }

    }
}

using Hackathon_2024_API.Models;
using Hackathon_2024_API.Schemas;

namespace Hackathon_2024_API.Services
{
    public interface IPackageService
    {
        Task<Package> CreatePackageAsync(Package package);
    }
}

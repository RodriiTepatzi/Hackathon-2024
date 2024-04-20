using System;
using Hackathon_2024_API.Models;
using Hackathon_2024_API.Schemas;


namespace Hackathon_2024_API.Services
{
    public interface IApplicationUsersService
    {
        Task<ApplicationUser> CreateUserAsync(ApplicationUsersSchema applicationUsersSchema);
        Task<ApplicationUser?> GetUserByEmailAsync(string email);
        

    }
}

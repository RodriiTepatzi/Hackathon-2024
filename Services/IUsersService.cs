using System;
using Hackathon_2024_API.Models;
using Hackathon_2024_API.Schemas;


namespace Hackathon_2024_API.Services
{
    public interface IUsersService
    {
        Task<ApplicationUser?> CreateUserAsync(UsersSchema applicationUsersSchema);
        Task<ApplicationUser?> GetUserByEmailAsync(string email);
	}
}

using Hackathon_2024_API.Data;
using Hackathon_2024_API.Models;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Hackathon_2024_API.Schemas;
using Hackathon_2024_API.Models.Enums;

namespace Hackathon_2024_API.Services
{
    public class UsersService : IUsersService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public UsersService(AppDbContext context, UserManager<ApplicationUser> userManager) {

            _context = context;
            _userManager = userManager;
        }

		public async Task<ApplicationUser?> CreateUserAsync(UsersSchema applicationUsersSchema) {

            var user = new ApplicationUser {

                UserName = applicationUsersSchema.Email,
                Email = applicationUsersSchema.Email,
                FirstName = applicationUsersSchema.FirstName,
                LastName = applicationUsersSchema.LastName,
                PictureUrl = applicationUsersSchema.PictureUrl,
                WorkId = applicationUsersSchema.WorkId,
                PhoneNumber = applicationUsersSchema.PhoneNumber,
                UserStatus = UserStatus.Active,
            };


            var result = await _userManager.CreateAsync(user, applicationUsersSchema.Password!);

			if (result.Succeeded)
				return user;
			else
				return null;
        }

        public async Task<ApplicationUser?> GetUserByEmailAsync(string email) {

            try
            {
				var user = await _userManager.FindByEmailAsync(email);

				if (user == null) return null;

				return user;

            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
	}
}

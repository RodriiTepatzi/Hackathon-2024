using Hackathon_2024_API.Data;
using Hackathon_2024_API.Models;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Hackathon_2024_API.Schemas;

namespace Hackathon_2024_API.Services
{
    public class ApplicationUsersService:IApplicationUsersService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public ApplicationUsersService(AppDbContext context, UserManager<ApplicationUser> userManager) { 

            _context = context;
            _userManager = userManager;


        }

        public async Task<ApplicationUser> CreateUserAsync(ApplicationUsersSchema applicationUsersSchema) {

            var user = new ApplicationUser {

                UserName = applicationUsersSchema.Email,
                Email = applicationUsersSchema.Email,
                FirstName = applicationUsersSchema.FirstName,
                LastName = applicationUsersSchema.LastName,
                PictureUrl = applicationUsersSchema.PictureUrl,
                WorkId = applicationUsersSchema.WorkId,
                PhoneNumber = applicationUsersSchema.PhoneNumber,
                

            };


            await _userManager.CreateAsync(user, applicationUsersSchema.Password!);

            var entity = _context.Entry(user);
            var result = entity.Entity;
            entity.State = EntityState.Added;

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<ApplicationUser?> GetUserByEmailAsync(string email) {

            try
            {

                var result = await _context.ApplicationUsers.SingleOrDefaultAsync(i => i.Email == email);

                if (result == null) return null;

                var entity = _context.Entry(result);
            }
            catch (InvalidOperationException)
            {
                return null;
            }

            return null;
        }

    }
}

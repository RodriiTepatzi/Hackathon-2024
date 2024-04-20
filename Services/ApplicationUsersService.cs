using Hackathon_2024_API.Data;
using Hackathon_2024_API.Models;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Hackathon_2024_API.Schemas;

namespace Hackathon_2024_API.Services
{
    public class ApplicationUsersService : IApplicationUsersService
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
                UserStatus = "pending",


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

        public async Task<ApplicationUser?> GetUserByIDAsync(string id)
        {
            try
            {

                var result = await _context.ApplicationUsers.SingleOrDefaultAsync(i => i.Id == id);

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

        public async Task<ApplicationUser?> GetUserByPhoneAsync(string phone)
        {
            try
            {

                var result = await _context.ApplicationUsers.SingleOrDefaultAsync(i => i.PhoneNumber == phone);

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

    }
}

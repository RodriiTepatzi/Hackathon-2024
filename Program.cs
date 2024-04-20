
using Hackathon_2024_API.Controllers;
using Hackathon_2024_API.Data;
using Hackathon_2024_API.Models;
using Hackathon_2024_API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hackathon_2024_API
{
	public class Program
	{
		public static IConfiguration? Configuration { get; private set; }

		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			Configuration = builder.Configuration;

			builder.Services.AddDbContext<AppDbContext>(
				options => options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnectionString"),
					providerOptions => providerOptions.EnableRetryOnFailure()
				))
				.AddIdentityCore<ApplicationUser>()
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<AppDbContext>();

			builder.Services.AddTransient<IUsersService, UsersService>();
			builder.Services.AddTransient<IShipingService, ShipingService>();
			builder.Services.AddTransient<IPackageService, PackageService>();


			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
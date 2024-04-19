
using Hackathon_2024_API.Data;
using Hackathon_2024_API.Models;
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

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<AppDbContext>(
				options => options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnectionString"),
					providerOptions => providerOptions.EnableRetryOnFailure()
				))
				.AddIdentityCore<ApplicationUser>()
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<AppDbContext>();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
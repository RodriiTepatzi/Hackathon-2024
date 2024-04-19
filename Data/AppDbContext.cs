using Hackathon_2024_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_2024_API.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			builder.EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		DbSet<ApplicationUser> ApplicationUsers;

	}
}

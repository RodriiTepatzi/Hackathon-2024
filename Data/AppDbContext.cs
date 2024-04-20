using Hackathon_2024_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_2024_API.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

			// Habilitamos el registro de datos sensibles
			optionsBuilder.EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<ApplicationUser> ApplicationUsers { get; set; }

	}
}

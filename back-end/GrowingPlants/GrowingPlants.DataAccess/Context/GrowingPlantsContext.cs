using GrowingPlants.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GrowingPlants.DataAccess.Context
{
	public class GrowingPlantsContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public GrowingPlantsContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<User>().ToTable("User");
			modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
		}
	}
}

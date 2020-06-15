using GrowingPlants.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GrowingPlants.DataAccess.Context
{
	public class GrowingPlantsContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Tree> Trees { get; set; }
		public DbSet<Temperature> Temperatures { get; set; }

		public GrowingPlantsContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			UserBuilder(modelBuilder);
			TreeBuilder(modelBuilder);
			TemperatureBuilder(modelBuilder);
		}

		private static void TemperatureBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Temperature>().ToTable("Temperature");
			modelBuilder.Entity<Temperature>().Property(x => x.Id).ValueGeneratedOnAdd();
		}

		private static void TreeBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Tree>().ToTable("Tree");
			modelBuilder.Entity<Tree>().Property(x => x.Id).ValueGeneratedOnAdd();

			modelBuilder.Entity<Tree>()
				.HasOne(t => t.Temperature)
				.WithMany(t => t.Trees)
				.HasForeignKey(t => t.TemperatureId);
		}

		private static void UserBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().ToTable("User");
			modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
		}
	}
}

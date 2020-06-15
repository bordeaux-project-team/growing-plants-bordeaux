using GrowingPlants.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GrowingPlants.DataAccess.Context
{
	public class GrowingPlantsContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Tree> Trees { get; set; }
		public DbSet<Temperature> Temperatures { get; set; }
		public DbSet<Light> Lights { get; set; }
		public DbSet<Humidity> HumiditySet { get; set; }
		public DbSet<MeasurementUnit> MeasurementUnits { get; set; }

		public GrowingPlantsContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			UserBuilder(modelBuilder);
			TreeBuilder(modelBuilder);
			TemperatureBuilder(modelBuilder);
			LightBuilder(modelBuilder);
			HumidityBuilder(modelBuilder);
			MeasurementUnitBuilder(modelBuilder);
		}

		private static void MeasurementUnitBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MeasurementUnit>().ToTable("MeasurementUnit");
			modelBuilder.Entity<MeasurementUnit>().Property(x => x.Id).ValueGeneratedOnAdd();
		}

		private static void HumidityBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Humidity>().ToTable("Humidity");
			modelBuilder.Entity<Humidity>().Property(x => x.Id).ValueGeneratedOnAdd();

			modelBuilder.Entity<Humidity>()
				.HasOne(t => t.MeasurementUnit)
				.WithMany(t => t.HumidityList)
				.HasForeignKey(t => t.MeasurementUnitId);
		}

		private static void LightBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Light>().ToTable("Light");
			modelBuilder.Entity<Light>().Property(x => x.Id).ValueGeneratedOnAdd();

			modelBuilder.Entity<Light>()
				.HasOne(t => t.MeasurementUnit)
				.WithMany(t => t.Lights)
				.HasForeignKey(t => t.MeasurementUnitId);
		}

		private static void TemperatureBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Temperature>().ToTable("Temperature");
			modelBuilder.Entity<Temperature>().Property(x => x.Id).ValueGeneratedOnAdd();


			modelBuilder.Entity<Temperature>()
				.HasOne(t => t.MeasurementUnit)
				.WithMany(t => t.Temperatures)
				.HasForeignKey(t => t.MeasurementUnitId);
		}

		private static void TreeBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Tree>().ToTable("Tree");
			modelBuilder.Entity<Tree>().Property(x => x.Id).ValueGeneratedOnAdd();

			modelBuilder.Entity<Tree>()
				.HasOne(t => t.Temperature)
				.WithMany(t => t.Trees)
				.HasForeignKey(t => t.TemperatureId);

			modelBuilder.Entity<Tree>()
				.HasOne(t => t.Light)
				.WithMany(l => l.Trees)
				.HasForeignKey(t => t.LightId);

			modelBuilder.Entity<Tree>()
				.HasOne(t => t.Humidity)
				.WithMany(h => h.Trees)
				.HasForeignKey(t => t.HumidityId);
		}

		private static void UserBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().ToTable("User");
			modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
		}
	}
}

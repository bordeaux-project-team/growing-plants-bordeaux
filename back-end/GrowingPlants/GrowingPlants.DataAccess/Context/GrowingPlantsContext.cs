﻿using GrowingPlants.Infrastructure.Models;
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
		public DbSet<FavoriteTree> FavoriteTrees { get; set; }
		public DbSet<PlantingProcess> PlantingProcesses { get; set; }
		public DbSet<PlantingEnvironment> PlantingEnvironments { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<PlantingAction> PlantingActions { get; set; }
		public DbSet<ProcessStep> ProcessSteps { get; set; }
		public DbSet<Notification> Notifications { get; set; }
		public DbSet<Recurrence> Recurrences { get; set; }


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
			FavoriteTreeBuilder(modelBuilder);
			PlantingProcessBuilder(modelBuilder);
			PlantingEnvironmentBuilder(modelBuilder);
			CountryBuilder(modelBuilder);
			PlantingActionBuilder(modelBuilder);
			ProcessStepBuilder(modelBuilder);
			NotificationBuilder(modelBuilder);
			RecurrenceBuilder(modelBuilder);
		}

		private static void RecurrenceBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Recurrence>().ToTable("Recurrence");
			modelBuilder.Entity<Recurrence>().Property(x => x.Id).ValueGeneratedOnAdd();
		}

		private static void NotificationBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Notification>().ToTable("Notification");
			modelBuilder.Entity<Notification>().Property(x => x.Id).ValueGeneratedOnAdd();
		}

		private static void ProcessStepBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProcessStep>().ToTable("ProcessStep");
			modelBuilder.Entity<ProcessStep>().Property(x => x.Id).ValueGeneratedOnAdd();
		}

		private static void PlantingActionBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PlantingAction>().ToTable("PlantingAction");
			modelBuilder.Entity<PlantingAction>().Property(x => x.Id).ValueGeneratedOnAdd();
		}

		private static void CountryBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Country>().ToTable("Country");
			modelBuilder.Entity<Country>().Property(x => x.Id).ValueGeneratedOnAdd();
		}

		private static void PlantingEnvironmentBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PlantingEnvironment>().ToTable("PlantingEnvironment");
			modelBuilder.Entity<PlantingEnvironment>().Property(x => x.Id).ValueGeneratedOnAdd();
		}

		private static void PlantingProcessBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PlantingProcess>().ToTable("PlantingProcess");
			modelBuilder.Entity<PlantingProcess>().Property(x => x.Id).ValueGeneratedOnAdd();
		}

		private static void FavoriteTreeBuilder(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<FavoriteTree>().ToTable("FavoriteTree");
			modelBuilder.Entity<FavoriteTree>().Property(x => x.Id).ValueGeneratedOnAdd();

			modelBuilder.Entity<FavoriteTree>()
				.HasOne(ft => ft.Tree)
				.WithMany(t => t.FavoriteTrees)
				.HasForeignKey(ft => ft.TreeId);

			modelBuilder.Entity<FavoriteTree>()
				.HasOne(ft => ft.User)
				.WithMany(t => t.FavoriteTrees)
				.HasForeignKey(ft => ft.UserId);
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

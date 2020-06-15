﻿// <auto-generated />
using System;
using GrowingPlants.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GrowingPlants.DataAccess.Migrations
{
    [DbContext(typeof(GrowingPlantsContext))]
    [Migration("20200615095327_AddPlantingProcess")]
    partial class AddPlantingProcess
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.FavoriteTree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<int?>("TreeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TreeId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoriteTree");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.Humidity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromUnit")
                        .HasColumnType("int");

                    b.Property<int?>("MeasurementUnitId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToUnit")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementUnitId");

                    b.ToTable("Humidity");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.Light", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromUnit")
                        .HasColumnType("int");

                    b.Property<int?>("MeasurementUnitId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToUnit")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementUnitId");

                    b.ToTable("Light");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.MeasurementUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MeasurementUnit");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.PlantingAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MeasurementUnitId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProcessStepId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementUnitId");

                    b.HasIndex("ProcessStepId");

                    b.ToTable("PlantingAction");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.PlantingEnvironment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExposureTime")
                        .HasColumnType("int");

                    b.Property<int?>("HumidityId")
                        .HasColumnType("int");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int?>("LightId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TemperatureId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("HumidityId");

                    b.HasIndex("LightId");

                    b.HasIndex("TemperatureId");

                    b.ToTable("PlantingEnvironment");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.PlantingProcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FloweringDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("GerminationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HarvestDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PlantingEnvironmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TreeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VegetativeDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PlantingEnvironmentId");

                    b.HasIndex("TreeId");

                    b.ToTable("PlantingProcess");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.ProcessStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NotificationId")
                        .HasColumnType("int");

                    b.Property<int?>("PlantingActionId")
                        .HasColumnType("int");

                    b.Property<int?>("PlantingProcessId")
                        .HasColumnType("int");

                    b.Property<int?>("RecurrenceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NotificationId");

                    b.HasIndex("PlantingActionId");

                    b.HasIndex("PlantingProcessId");

                    b.HasIndex("RecurrenceId");

                    b.ToTable("ProcessStep");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.Recurrence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Recurrence");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.Temperature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromDegree")
                        .HasColumnType("int");

                    b.Property<int?>("MeasurementUnitId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToDegree")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementUnitId");

                    b.ToTable("Temperature");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.Tree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComparisonAgainst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComparisonWith")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExposureTime")
                        .HasColumnType("int");

                    b.Property<int>("FloweringTime")
                        .HasColumnType("int");

                    b.Property<string>("GardenType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GerminationTime")
                        .HasColumnType("int");

                    b.Property<int>("HarvestTime")
                        .HasColumnType("int");

                    b.Property<int?>("HumidityId")
                        .HasColumnType("int");

                    b.Property<int?>("LightId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlantingEnvironmentId")
                        .HasColumnType("int");

                    b.Property<string>("PlantingGuide")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TemperatureId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("VegetativeTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HumidityId");

                    b.HasIndex("LightId");

                    b.HasIndex("PlantingEnvironmentId");

                    b.HasIndex("TemperatureId");

                    b.ToTable("Tree");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.FavoriteTree", b =>
                {
                    b.HasOne("GrowingPlants.Infrastructure.Models.Tree", "Tree")
                        .WithMany("FavoriteTrees")
                        .HasForeignKey("TreeId");

                    b.HasOne("GrowingPlants.Infrastructure.Models.User", "User")
                        .WithMany("FavoriteTrees")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.Humidity", b =>
                {
                    b.HasOne("GrowingPlants.Infrastructure.Models.MeasurementUnit", "MeasurementUnit")
                        .WithMany("HumidityList")
                        .HasForeignKey("MeasurementUnitId");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.Light", b =>
                {
                    b.HasOne("GrowingPlants.Infrastructure.Models.MeasurementUnit", "MeasurementUnit")
                        .WithMany("Lights")
                        .HasForeignKey("MeasurementUnitId");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.PlantingAction", b =>
                {
                    b.HasOne("GrowingPlants.Infrastructure.Models.MeasurementUnit", "MeasurementUnit")
                        .WithMany("PlantingActions")
                        .HasForeignKey("MeasurementUnitId");

                    b.HasOne("GrowingPlants.Infrastructure.Models.ProcessStep", null)
                        .WithMany("PlantingActions")
                        .HasForeignKey("ProcessStepId");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.PlantingEnvironment", b =>
                {
                    b.HasOne("GrowingPlants.Infrastructure.Models.Country", "Country")
                        .WithMany("PlantingEnvironments")
                        .HasForeignKey("CountryId");

                    b.HasOne("GrowingPlants.Infrastructure.Models.Humidity", "Humidity")
                        .WithMany("PlantingEnvironments")
                        .HasForeignKey("HumidityId");

                    b.HasOne("GrowingPlants.Infrastructure.Models.Light", "Light")
                        .WithMany("PlantingEnvironments")
                        .HasForeignKey("LightId");

                    b.HasOne("GrowingPlants.Infrastructure.Models.Temperature", "Temperature")
                        .WithMany("PlantingEnvironments")
                        .HasForeignKey("TemperatureId");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.PlantingProcess", b =>
                {
                    b.HasOne("GrowingPlants.Infrastructure.Models.PlantingEnvironment", "PlantingEnvironment")
                        .WithMany()
                        .HasForeignKey("PlantingEnvironmentId");

                    b.HasOne("GrowingPlants.Infrastructure.Models.Tree", "Tree")
                        .WithMany()
                        .HasForeignKey("TreeId");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.ProcessStep", b =>
                {
                    b.HasOne("GrowingPlants.Infrastructure.Models.Notification", "Notification")
                        .WithMany("ProcessSteps")
                        .HasForeignKey("NotificationId");

                    b.HasOne("GrowingPlants.Infrastructure.Models.PlantingAction", "PlantingAction")
                        .WithMany()
                        .HasForeignKey("PlantingActionId");

                    b.HasOne("GrowingPlants.Infrastructure.Models.PlantingProcess", "PlantingProcess")
                        .WithMany()
                        .HasForeignKey("PlantingProcessId");

                    b.HasOne("GrowingPlants.Infrastructure.Models.Recurrence", "Recurrence")
                        .WithMany()
                        .HasForeignKey("RecurrenceId");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.Temperature", b =>
                {
                    b.HasOne("GrowingPlants.Infrastructure.Models.MeasurementUnit", "MeasurementUnit")
                        .WithMany("Temperatures")
                        .HasForeignKey("MeasurementUnitId");
                });

            modelBuilder.Entity("GrowingPlants.Infrastructure.Models.Tree", b =>
                {
                    b.HasOne("GrowingPlants.Infrastructure.Models.Humidity", "Humidity")
                        .WithMany("Trees")
                        .HasForeignKey("HumidityId");

                    b.HasOne("GrowingPlants.Infrastructure.Models.Light", "Light")
                        .WithMany("Trees")
                        .HasForeignKey("LightId");

                    b.HasOne("GrowingPlants.Infrastructure.Models.PlantingEnvironment", null)
                        .WithMany("Trees")
                        .HasForeignKey("PlantingEnvironmentId");

                    b.HasOne("GrowingPlants.Infrastructure.Models.Temperature", "Temperature")
                        .WithMany("Trees")
                        .HasForeignKey("TemperatureId");
                });
#pragma warning restore 612, 618
        }
    }
}

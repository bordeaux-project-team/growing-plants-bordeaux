using System;
using System.Collections.Generic;
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
        public DbSet<FavoriteTree> FavoriteTrees { get; set; }
        public DbSet<PlantingProcess> PlantingProcesses { get; set; }
        public DbSet<PlantingEnvironment> PlantingEnvironments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PlantingAction> PlantingActions { get; set; }
        public DbSet<ProcessStep> ProcessSteps { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Recurrence> Recurrences { get; set; }
        public DbSet<PlantingSpot> PlantingSpots { get; set; }
        public DbSet<PlantType> PlantTypes { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Picture> Pictures { get; set; }

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
            PlantingSpotBuilder(modelBuilder);
            PlantTypeBuilder(modelBuilder);
            GalleryBuilder(modelBuilder);
            PictureBuilder(modelBuilder);
        }

        private static void GalleryBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gallery>().ToTable("Gallery");
            modelBuilder.Entity<Gallery>().Property(x => x.Id).ValueGeneratedOnAdd();
        }

        private static void PictureBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Picture>().ToTable("Picture");
            modelBuilder.Entity<Picture>().Property(x => x.Id).ValueGeneratedOnAdd();
        }

        private static void PlantTypeBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlantType>().ToTable("PlantType");
            modelBuilder.Entity<PlantType>().Property(x => x.Id).ValueGeneratedOnAdd();
        }

        private static void PlantingSpotBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlantingSpot>().ToTable("PlantingSpot");
            modelBuilder.Entity<PlantingSpot>().Property(x => x.Id).ValueGeneratedOnAdd();
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
        }

        private static void LightBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Light>().ToTable("Light");
            modelBuilder.Entity<Light>().Property(x => x.Id).ValueGeneratedOnAdd();
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

            modelBuilder.Entity<Tree>().HasData(new List<Tree>
            {
                new Tree
                {
                    Id = 1,
                    Name = "Chamaecyparis lawsoniana",
                    Description = "Chamaecyparis lawsoniana, known as Port Orford cedar or Lawson cypress, is a species of conifer in the genus Chamaecyparis, family Cupressaceae. It is native to Oregon and northwestern California, and grows from sea level up to 1,500 m (4,900 ft) in the valleys of the Klamath Mountains, often along streams",
                    EnvironmentType = "Outdoor",
                    ExposureTime = 5,
                    FloweringTime = 12,
                    GerminationTime = 24,
                    HarvestTime = 30,
                    WaterLevel = 8,
                    Temperature = "36 Degree",
                    VegetativeTime = 7,
                    Humidity = "47",
                    Light = "88",
                    PlantingGuide = "Just water it",
                    ComparisonAgainst = "Unknown",
                    ComparisonWith = "Unknown",
                    PlantType = "Tree",
                    CreatedAt = new DateTime(2020, 8, 30, 9, 49, 0),
                },
                new Tree
                {
                    Id = 2,
                    Name = "Blackberry",
                    Description = "The blackberry is an edible fruit made by any of several species in the Rubus genus of the Rosaceae family. The blackberry shrub is called 'bramble' in Britain, but in the western U.S. 'caneberry' is the term is used for both blackberries and raspberries",
                    EnvironmentType = "Indoor",
                    ExposureTime = 15,
                    FloweringTime = 32,
                    GerminationTime = 45,
                    HarvestTime = 23,
                    WaterLevel = 14,
                    Temperature = "16 Degree",
                    VegetativeTime = 4,
                    Humidity = "49",
                    Light = "48",
                    PlantingGuide = "Just water it",
                    ComparisonAgainst = "Unknown",
                    ComparisonWith = "Unknown",
                    PlantType = "Fruit",
                    CreatedAt = new DateTime(2020, 8, 30, 9, 49, 0),
                },
                new Tree
                {
                    Id = 3,
                    Name = "Apple",
                    Description = "The apple tree (Malus domestica) is a tree that grows fruit (such as apples) in the rose family best known for its juicy, tasty fruit. It is grown worldwide as a fruit tree. It is considered to be a low-cost fruit harvestable all over the world.",
                    EnvironmentType = "Indoor",
                    ExposureTime = 65,
                    FloweringTime = 12,
                    GerminationTime = 65,
                    HarvestTime = 10,
                    WaterLevel = 24,
                    Temperature = "16 Degree",
                    VegetativeTime = 36,
                    Humidity = "19",
                    Light = "49",
                    PlantingGuide = "Just water it",
                    ComparisonAgainst = "Unknown",
                    ComparisonWith = "Unknown",
                    PlantType = "Fruit",
                    CreatedAt = new DateTime(2020, 8, 30, 9, 49, 0),
                },
                new Tree
                {
                    Id = 4,
                    Name = "Pineapple",
                    Description = "The pineapple is a fruit. It is native to South America, Central America and the Caribbean. The word 'pineapple' came from European explorers, who thought the fruit looked similar to a pine cone.",
                    EnvironmentType = "Indoor",
                    ExposureTime = 11,
                    FloweringTime = 34,
                    GerminationTime = 32,
                    HarvestTime = 15,
                    WaterLevel = 22,
                    Temperature = "16 Degree",
                    VegetativeTime = 31,
                    Humidity = "15",
                    Light = "2",
                    PlantingGuide = "Just water it",
                    ComparisonAgainst = "Unknown",
                    ComparisonWith = "Unknown",
                    PlantType = "Fruit",
                    CreatedAt = new DateTime(2020, 8, 30, 9, 49, 0),
                },
                new Tree
                {
                    Id = 5,
                    Name = "Banana",
                    Description = "A banana is the common name for a type of fruit and also the name for the herbaceous plants that grow it. These plants belong to the genus Musa. They are native to the tropical region of southeast Asia.",
                    EnvironmentType = "Outdoor",
                    ExposureTime = 12,
                    FloweringTime = 12,
                    GerminationTime = 12,
                    HarvestTime = 15,
                    WaterLevel = 4,
                    Temperature = "50 Degree",
                    VegetativeTime = 32,
                    Humidity = "55",
                    Light = "10",
                    PlantingGuide = "Just water it",
                    ComparisonAgainst = "Unknown",
                    ComparisonWith = "Unknown",
                    PlantType = "Fruit",
                    CreatedAt = new DateTime(2020, 8, 30, 9, 49, 0),
                },
                new Tree
                {
                    Id = 6,
                    Name = "Umbellularia",
                    Description = "Umbellularia californica is a large hardwood tree native to coastal forests and the Sierra foothills of California, as well as to coastal forests extending into Oregon. It is endemic to the California Floristic Province. It is the sole species in the genus Umbellularia.",
                    EnvironmentType = "Outdoor",
                    ExposureTime = 5,
                    FloweringTime = 12,
                    GerminationTime = 24,
                    HarvestTime = 30,
                    WaterLevel = 8,
                    Temperature = "36 Degree",
                    VegetativeTime = 7,
                    Humidity = "47",
                    Light = "88",
                    PlantingGuide = "Just water it",
                    ComparisonAgainst = "Unknown",
                    ComparisonWith = "Unknown",
                    PlantType = "Herb",
                    CreatedAt = new DateTime(2020, 8, 30, 9, 49, 0),
                },
                new Tree
                {
                    Id = 7,
                    Name = "Cicely",
                    Description = "Myrrhis odorata, with common names cicely (/ˈsɪsəli/), sweet cicely, myrrh, garden myrrh, and sweet chervil, is a herbaceous perennial plant belonging to the celery family Apiaceae. It is one of two accepted species in the genus Myrrhis.",
                    EnvironmentType = "Indoor",
                    ExposureTime = 15,
                    FloweringTime = 32,
                    GerminationTime = 45,
                    HarvestTime = 23,
                    WaterLevel = 14,
                    Temperature = "16 Degree",
                    VegetativeTime = 4,
                    Humidity = "49",
                    Light = "48",
                    PlantingGuide = "Just water it",
                    ComparisonAgainst = "Unknown",
                    ComparisonWith = "Unknown",
                    PlantType = "Herb",
                    CreatedAt = new DateTime(2020, 8, 30, 9, 49, 0),
                },
                new Tree
                {
                    Id = 8,
                    Name = "Thai basil",
                    Description = "Thai basil (Thai: โหระพา, RTGS: horapha, ISO: h̄oraphā, pronounced [hǒː.rá(ʔ).pʰāː]; Vietnamese: húng quế; in Taiwan: 九層塔) is a type of basil native to Southeast Asia that has been cultivated to provide distinctive traits. Widely used throughout Southeast Asia, its flavor, described as anise- and licorice-like and slightly spicy, is more stable under high or extended cooking temperatures than that of sweet basil. Thai basil has small, narrow leaves, purple stems, and pink-purple flowers.",
                    EnvironmentType = "Outdoor",
                    ExposureTime = 65,
                    FloweringTime = 12,
                    GerminationTime = 65,
                    HarvestTime = 10,
                    WaterLevel = 24,
                    Temperature = "16 Degree",
                    VegetativeTime = 36,
                    Humidity = "19",
                    Light = "49",
                    PlantingGuide = "Just water it",
                    ComparisonAgainst = "Unknown",
                    ComparisonWith = "Unknown",
                    PlantType = "Herb",
                    CreatedAt = new DateTime(2020, 8, 30, 9, 49, 0),
                },
                new Tree
                {
                    Id = 9,
                    Name = "Ajwain",
                    Description = "Ajwain, ajowan[3] (/ˈædʒəwɒn/), or Trachyspermum ammi—also known as ajowan caraway, bishop's weed,[4] or carom—is an annual herb in the family Apiaceae (or Umbelliferae). Both the leaves and the seed‑like fruit (often mistakenly called seeds) of the plant are consumed by humans. The name \"bishop's weed\" also is a common name for other plants. The \"seed\" (i.e., the fruit) is often confused with lovage \"seed\"",
                    EnvironmentType = "Indoor",
                    ExposureTime = 11,
                    FloweringTime = 34,
                    GerminationTime = 32,
                    HarvestTime = 15,
                    WaterLevel = 22,
                    Temperature = "16 Degree",
                    VegetativeTime = 31,
                    Humidity = "15",
                    Light = "2",
                    PlantingGuide = "Just water it",
                    ComparisonAgainst = "Unknown",
                    ComparisonWith = "Unknown",
                    PlantType = "Herb",
                    CreatedAt = new DateTime(2020, 8, 30, 9, 49, 0),
                },
                new Tree
                {
                    Id = 10,
                    Name = "Hornbeam",
                    Description = "Hornbeams are hardwood trees in the flowering plant genus Carpinus in the birch family Betulaceae. The 30–40 species occur across much of the temperate regions of the Northern Hemisphere.",
                    EnvironmentType = "Outdoor",
                    ExposureTime = 12,
                    FloweringTime = 12,
                    GerminationTime = 12,
                    HarvestTime = 15,
                    WaterLevel = 4,
                    Temperature = "50 Degree",
                    VegetativeTime = 32,
                    Humidity = "55",
                    Light = "10",
                    PlantingGuide = "Just water it",
                    ComparisonAgainst = "Unknown",
                    ComparisonWith = "Unknown",
                    PlantType = "Tree",
                    CreatedAt = new DateTime(2020, 8, 30, 9, 49, 0),
                }
            });
        }

        private static void UserBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}

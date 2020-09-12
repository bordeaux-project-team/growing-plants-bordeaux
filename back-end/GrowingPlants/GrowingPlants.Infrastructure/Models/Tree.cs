using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GrowingPlants.Infrastructure.Models
{
    public class Tree : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ComparisonWith { get; set; }
        public string ComparisonAgainst { get; set; }
        public int? PictureId { get; set; }
        [JsonIgnore]
        public Picture Picture { get; set; }
        public int GerminationTime { get; set; } // Number of days
        public int VegetativeTime { get; set; } // Number of days
        public int FloweringTime { get; set; } // Number of days
        public int HarvestTime { get; set; } // Number of days
        public string Light { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string PlantType { get; set; }
        public int WaterLevel { get; set; }
        public string EnvironmentType { get; set; }
        public string PlantingGuide { get; set; }
        public int ExposureTime { get; set; } // Number of hours
        [JsonIgnore]
        public List<FavoriteTree> FavoriteTrees { get; set; }
        [JsonIgnore]
        public List<PlantingProcess> PlantingProcesses { get; set; }
    }
}

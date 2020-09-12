using System.Text.Json.Serialization;

namespace GrowingPlants.Infrastructure.Models
{
    public class PlantingSpot : BaseModel
    {
        public int? TreeId { get; set; }
        public Tree Tree { get; set; }
        public int? PlantingEnvironmentId { get; set; }
        [JsonIgnore]
        public PlantingEnvironment PlantingEnvironment { get; set; }
        public int Position { get; set; }
        public int Amount { get; set; } // Number of trees in that position
    }
}

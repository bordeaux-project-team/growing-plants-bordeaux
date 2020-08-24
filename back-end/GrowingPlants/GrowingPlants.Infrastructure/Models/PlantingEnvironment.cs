using System.Collections.Generic;

namespace GrowingPlants.Infrastructure.Models
{
    public class PlantingEnvironment : BaseModel
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public string Country { get; set; }
        public string Light { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public int ExposureTime { get; set; } // Number of hours
        public string EnvironmentType { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public List<PlantingSpot> PlantingSpots { get; set; }
    }
}

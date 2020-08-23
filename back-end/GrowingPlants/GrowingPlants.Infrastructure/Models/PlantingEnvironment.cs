using System.Collections.Generic;

namespace GrowingPlants.Infrastructure.Models
{
    public class PlantingEnvironment : BaseModel
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public int? LightId { get; set; }
        public Light Light { get; set; }
        public int? TemperatureId { get; set; }
        public Temperature Temperature { get; set; }
        public int? HumidityId { get; set; }
        public Humidity Humidity { get; set; }
        public int ExposureTime { get; set; } // Number of hours
        public string EnvironmentType { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public List<PlantingSpot> PlantingSpots { get; set; }
    }
}

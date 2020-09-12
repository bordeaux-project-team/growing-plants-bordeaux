using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GrowingPlants.Infrastructure.Models
{
    public class PlantingProcess : BaseModel
    {
        public int? TreeId { get; set; }
        [JsonIgnore]
        public Tree Tree { get; set; }
        public int? UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime GerminationDate { get; set; }
        public DateTime VegetativeDate { get; set; }
        public DateTime FloweringDate { get; set; }
        public DateTime HarvestDate { get; set; }
        [JsonIgnore]
        public Gallery Gallery { get; set; }
        public int? PlantingSpotId { get; set; }
        [JsonIgnore]
        public PlantingSpot PlantingSpot { get; set; }
        [JsonIgnore]
        public List<ProcessStep> ProcessSteps { get; set; }
    }
}

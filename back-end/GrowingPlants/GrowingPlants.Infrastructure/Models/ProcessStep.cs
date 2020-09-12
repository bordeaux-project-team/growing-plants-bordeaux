using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GrowingPlants.Infrastructure.Models
{
    public class ProcessStep : BaseModel
    {
        public int? PlantingProcessId { get; set; }
        [JsonIgnore]
        public PlantingProcess PlantingProcess { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        [JsonIgnore]
        public List<PlantingAction> PlantingActions { get; set; }
    }
}

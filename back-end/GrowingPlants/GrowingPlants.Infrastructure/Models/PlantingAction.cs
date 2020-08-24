using System;

namespace GrowingPlants.Infrastructure.Models
{
    public class PlantingAction : BaseModel
    {
        public string Name { get; set; }
        public DateTime ActionTime { get; set; }
        public double Amount { get; set; }
        public string MeasurementUnit { get; set; }
        public string Description { get; set; }
        public int? ProcessStepId { get; set; }
        public ProcessStep ProcessStep { get; set; }
    }
}

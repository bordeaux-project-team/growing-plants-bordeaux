using System;
using System.Collections.Generic;

namespace GrowingPlants.Infrastructure.Models
{
    public class PlantingProcess : BaseModel
    {
        public int? TreeId { get; set; }
        public Tree Tree { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime GerminationDate { get; set; }
        public DateTime VegetativeDate { get; set; }
        public DateTime FloweringDate { get; set; }
        public DateTime HarvestDate { get; set; }
        public List<ProcessStep> ProcessSteps { get; set; }
    }
}

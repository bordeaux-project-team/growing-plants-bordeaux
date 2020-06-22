using System.Collections.Generic;

namespace GrowingPlants.Infrastructure.Models
{
    public class Gallery : BaseModel
    {
        public string Name { get; set; }
        public List<Picture> Pictures { get; set; }
        public int? PlantingProcessId { get; set; }
        public PlantingProcess PlantingProcess { get; set; }
    }
}

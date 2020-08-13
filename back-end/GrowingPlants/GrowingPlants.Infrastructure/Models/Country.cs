using System.Collections.Generic;

namespace GrowingPlants.Infrastructure.Models
{
    public class Country : BaseModel
    {
        public string Name { get; set; }
        public List<PlantingEnvironment> PlantingEnvironments { get; set; }
    }
}

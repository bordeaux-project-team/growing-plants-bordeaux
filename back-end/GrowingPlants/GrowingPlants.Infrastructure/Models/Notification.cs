using System.Collections.Generic;

namespace GrowingPlants.Infrastructure.Models
{
    public class Notification : BaseModel
    {
        public string Content { get; set; }
        public List<ProcessStep> ProcessSteps { get; set; }
    }
}

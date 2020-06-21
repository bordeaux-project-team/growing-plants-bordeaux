using System;
using System.Collections.Generic;

namespace GrowingPlants.Infrastructure.Models
{
    public class ProcessStep : BaseModel
    {
        public int? PlantingProcessId { get; set; }
        public PlantingProcess PlantingProcess { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public List<PlantingAction> PlantingActions { get; set; }
        public List<Recurrence> Recurrences { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}

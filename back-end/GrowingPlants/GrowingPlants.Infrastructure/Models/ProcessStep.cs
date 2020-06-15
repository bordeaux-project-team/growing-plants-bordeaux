using System;

namespace GrowingPlants.Infrastructure.Models
{
	public class ProcessStep : BaseModel
	{
		public int? PlantingActionId { get; set; }
		public PlantingAction PlantingAction { get; set; }
		public int? PlantingProcessId { get; set; }
		public PlantingProcess PlantingProcess { get; set; }
		public DateTime StartDate { get; set; }
		public string Description { get; set; }
		public int Amount { get; set; }
		public int? RecurrenceId { get; set; }
		public Recurrence Recurrence { get; set; }
		public int? NotificationId { get; set; }
		public Notification Notification { get; set; }
	}
}

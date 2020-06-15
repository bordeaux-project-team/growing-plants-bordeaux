using System.Collections.Generic;

namespace GrowingPlants.Infrastructure.Models
{
	public class PlantingAction : BaseModel
	{
		public string Name { get; set; }
		public string Icon { get; set; }
		public int? MeasurementUnitId { get; set; }
		public MeasurementUnit MeasurementUnit { get; set; }
		public string Description { get; set; }
		public List<ProcessStep> ProcessSteps { get; set; }
	}
}

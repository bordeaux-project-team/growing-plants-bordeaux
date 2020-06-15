using System.Collections.Generic;

namespace GrowingPlants.Infrastructure.Models
{
	public class Recurrence : BaseModel
	{
		public string Name { get; set; }
		public int Days { get; set; }
		public List<ProcessStep> ProcessSteps { get; set; }
	}
}

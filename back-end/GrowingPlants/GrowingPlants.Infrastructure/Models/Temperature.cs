using System.Collections.Generic;

namespace GrowingPlants.Infrastructure.Models
{
	public class Temperature : BaseModel
	{
		public string Name { get; set; }
		public int FromDegree { get; set; }
		public int ToDegree { get; set; }
		public int MeasurementId { get; set; }

		public List<Tree> Trees { get; set; }
	}
}

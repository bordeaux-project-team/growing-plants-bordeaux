using System.Collections.Generic;

namespace GrowingPlants.Infrastructure.Models
{
	public class MeasurementUnit : BaseModel
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public List<Temperature> Temperatures { get; set; }
		// public List<PlantingAction> PlantingActions { get; set; }
		public List<Light> Lights { get; set; }
		public List<Humidity> HumidityList { get; set; }
	}
}

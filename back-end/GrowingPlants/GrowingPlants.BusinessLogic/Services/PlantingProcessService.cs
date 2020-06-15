using GrowingPlants.BusinessLogic.IServices;
using Microsoft.Extensions.Logging;

namespace GrowingPlants.BusinessLogic.Services
{
	public class PlantingProcessService : IPlantingProcessService
	{
		private readonly ILogger _logger;

		public PlantingProcessService(ILoggerFactory loggerFactory)
		{
			_logger = loggerFactory.CreateLogger(typeof(PlantingProcessService));
		}
	}
}

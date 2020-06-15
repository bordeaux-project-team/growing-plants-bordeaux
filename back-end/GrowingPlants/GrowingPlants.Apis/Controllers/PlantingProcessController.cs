using GrowingPlants.BusinessLogic.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GrowingPlants.Apis.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PlantingProcessController : ControllerBase
	{
		private readonly ILogger _logger;

		public PlantingProcessController(ILoggerFactory loggerFactory)
		{
			_logger = loggerFactory.CreateLogger(typeof(PlantingProcessController));
		}
	}
}

using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GrowingPlants.Apis.Controllers
{
	[Authorize(Roles = Constants.UserRole.Admin)]
	[ApiController]
	[Route("api/[controller]")]
	public class CountryController : ControllerBase
	{
		private readonly ICountryService _countryService;
		private readonly ILogger _logger;

		public CountryController(ILoggerFactory loggerFactory, ICountryService countryService)
		{
			_countryService = countryService;
			_logger = loggerFactory.CreateLogger(typeof(CountryController));
		}
	}
}

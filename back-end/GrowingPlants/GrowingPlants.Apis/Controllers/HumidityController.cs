using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.Infrastructure.Models;
using GrowingPlants.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GrowingPlants.Apis.Controllers
{
	[Authorize(Roles = Constants.UserRole.Admin)]
	[ApiController]
	[Route("api/[controller]")]
	public class HumidityController : ControllerBase
	{
		private readonly IHumidityService _humidityService;
		private readonly ILogger _logger;

		public HumidityController(ILoggerFactory loggerFactory, IHumidityService humidityService)
		{
			_humidityService = humidityService;
			_logger = loggerFactory.CreateLogger(typeof(UserController));
		}


		[HttpPost]
		[Route("insert")]
		public async Task<ApiResult<bool>> InsertHumidityList(IEnumerable<Humidity> humidityList)
		{
			try
			{
				var stopwatch = Stopwatch.StartNew();
				_logger.LogInformation("Insert humidityList");

				var result = await _humidityService.InsertHumidityList(humidityList?.ToList());

				_logger.LogInformation("Insert humidityList complete");

				stopwatch.Stop();
				result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
				_logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogInformation($"Insert humidityList error: {ex}");

				return new ApiResult<bool>
				{
					Result = false,
					ApiCode = ApiCode.UnknownError,
					ErrorMessage = ex.ToString()
				};
			}
		}

		[HttpPut]
		[Route("update/{id}")]
		public async Task<ApiResult<bool>> UpdateHumidity(int id, Humidity humidity)
		{
			try
			{
				var stopwatch = Stopwatch.StartNew();
				_logger.LogInformation("Update humidity");

				humidity.Id = id;

				var result = await _humidityService.UpdateHumidity(humidity);

				_logger.LogInformation("Update humidity complete");

				stopwatch.Stop();
				result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
				_logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogInformation($"Update humidity error: {ex}");

				return new ApiResult<bool>
				{
					Result = false,
					ApiCode = ApiCode.UnknownError,
					ErrorMessage = ex.ToString()
				};
			}
		}
	}
}

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
	public class TemperatureController : ControllerBase
	{
		private readonly ITemperatureService _temperatureService;
		private readonly ILogger _logger;

		public TemperatureController(ILoggerFactory loggerFactory, ITemperatureService temperatureService)
		{
			_temperatureService = temperatureService;
			_logger = loggerFactory.CreateLogger(typeof(TemperatureController));
		}


		[HttpPost]
		[Route("insert")]
		public async Task<ApiResult<bool>> InsertTemperatures(IEnumerable<Temperature> temperatures)
		{
			try
			{
				var stopwatch = Stopwatch.StartNew();
				_logger.LogInformation("Insert temperatures");

				var result = await _temperatureService.InsertTemperatures(temperatures?.ToList());

				_logger.LogInformation("Insert temperatures complete");

				stopwatch.Stop();
				result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
				_logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogInformation($"Insert temperatures error: {ex}");

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
		public async Task<ApiResult<bool>> UpdateTemperature(int id, Temperature temperature)
		{
			try
			{
				var stopwatch = Stopwatch.StartNew();
				_logger.LogInformation("Update temperature");

				temperature.Id = id;

				var result = await _temperatureService.UpdateTemperature(temperature);

				_logger.LogInformation("Update temperature complete");

				stopwatch.Stop();
				result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
				_logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogInformation($"Update temperature error: {ex}");

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

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
	public class LightController : ControllerBase
	{
		private readonly ILightService _lightService;
		private readonly ILogger _logger;

		public LightController(ILoggerFactory loggerFactory, ILightService lightService)
		{
			_lightService = lightService;
			_logger = loggerFactory.CreateLogger(typeof(LightController));
		}


		[HttpPost]
		[Route("insert")]
		public async Task<ApiResult<bool>> InsertLights(IEnumerable<Light> lights)
		{
			try
			{
				var stopwatch = Stopwatch.StartNew();
				_logger.LogInformation("Insert lights");

				var result = await _lightService.InsertLights(lights?.ToList());

				_logger.LogInformation("Insert lights complete");

				stopwatch.Stop();
				result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
				_logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogInformation($"Insert lights error: {ex}");

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
		public async Task<ApiResult<bool>> UpdateTree(int id, Light light)
		{
			try
			{
				var stopwatch = Stopwatch.StartNew();
				_logger.LogInformation("Update light");

				light.Id = id;

				var result = await _lightService.UpdateLight(light);

				_logger.LogInformation("Update light complete");

				stopwatch.Stop();
				result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
				_logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogInformation($"Update light error: {ex}");

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

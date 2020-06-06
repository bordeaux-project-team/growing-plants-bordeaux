using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GrowingPlants.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GrowingPlants.Apis.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly ILogger _logger;

		public UserController(ILoggerFactory loggerFactory)
		{
			_logger = loggerFactory.CreateLogger(typeof(UserController));
		}

		[HttpGet]
		[Route("/test/{data}")]
		public async Task<ApiResult<string>> TestApiResult(string data)
		{
			var stopwatch = Stopwatch.StartNew();
			var apiResult = new ApiResult<string>();
			try
			{
				_logger.LogInformation("Test API");
				apiResult.Result = await Task.FromResult(data);
				apiResult.Succeed = true;
			}
			catch (Exception ex)
			{
				apiResult.Succeed = false;
				apiResult.Result = "Error";
				apiResult.Error = ex.ToString();
				_logger.LogInformation($"TestApiResult error: {ex}");
			}
			stopwatch.Stop();
			apiResult.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
			_logger.LogInformation($"Execution time: {apiResult.ExecutionTime}ms");

			return apiResult;
        }
	}
}

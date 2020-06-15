using System;
using System.Collections;
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
	public class TreeController : ControllerBase
	{
		private readonly ITreeService _treeService;
		private readonly ILogger _logger;

		public TreeController(ILoggerFactory loggerFactory, ITreeService treeService)
		{
			_treeService = treeService;
			_logger = loggerFactory.CreateLogger(typeof(UserController));
		}


		[HttpPost]
		[Route("insert")]
		public async Task<ApiResult<bool>> InsertTrees(IEnumerable<Tree> trees)
		{
			try
			{
				var stopwatch = Stopwatch.StartNew();
				_logger.LogInformation("Insert trees");

				var result = await _treeService.InsertTrees(trees?.ToList());

				_logger.LogInformation("Insert trees complete");

				stopwatch.Stop();
				result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
				_logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogInformation($"Insert trees error: {ex}");

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

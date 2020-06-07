using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.Infrastructure;
using GrowingPlants.Infrastructure.ApiModels;
using GrowingPlants.Infrastructure.DbModels;
using GrowingPlants.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GrowingPlants.Apis.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly ILogger _logger;

		public UserController(ILoggerFactory loggerFactory, IUserService userService)
		{
			_userService = userService;
			_logger = loggerFactory.CreateLogger(typeof(UserController));
		}

		[HttpGet]
		[Route("test/{data}")]
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
				apiResult.ErrorMessage = ex.ToString();
				_logger.LogInformation($"TestApiResult error: {ex}");
			}
			stopwatch.Stop();
			apiResult.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
			_logger.LogInformation($"Execution time: {apiResult.ExecutionTime}ms");

			return apiResult;
        }

		[AllowAnonymous]
		[HttpPost]
		[Route("register")]
		public async Task<ApiResult<bool>> Register(User user)
		{
			try
			{
				var stopwatch = Stopwatch.StartNew();
				_logger.LogInformation("Account registration");

				var result = await _userService.Register(user);

				_logger.LogInformation("Account registration complete");

				stopwatch.Stop();
				result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
				_logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogInformation($"Account registration error: {ex}");

				return new ApiResult<bool>
				{
					Succeed = false,
					Result = false,
					ErrorCode = ApiCode.UnknownError,
					ErrorMessage = ex.ToString()
				};
			}
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("login")]
		public async Task<ApiResult<UserLogin>> Login(LoginCredential loginCredential)
		{
			try
			{
				var stopwatch = Stopwatch.StartNew();

				_logger.LogInformation("User login");
				var result = await _userService.Login(loginCredential);
				_logger.LogInformation("User login complete");

				stopwatch.Stop();
				result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
				_logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogInformation($"User login error: {ex}");

				return new ApiResult<UserLogin>
				{
					Succeed = false,
					Result = null,
					ErrorCode = ApiCode.UnknownError,
					ErrorMessage = ex.ToString()
				};
			}
		}
	}
}

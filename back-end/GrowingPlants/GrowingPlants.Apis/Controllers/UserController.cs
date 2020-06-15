using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.Infrastructure.Models;
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

		[Authorize(Roles = Constants.UserRole.Admin)]
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
			}
			catch (Exception ex)
			{
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
		[Route("register-account")]
		public async Task<ApiResult<bool>> RegisterAccount(User user)
		{
			try
			{
				var stopwatch = Stopwatch.StartNew();
				_logger.LogInformation("Account registration");

				var result = await _userService.RegisterAccount(user);

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
					Result = false,
					ApiCode = ApiCode.UnknownError,
					ErrorMessage = ex.ToString()
				};
			}
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("login")]
		public async Task<ApiResult<User>> Login(LoginCredential loginCredential)
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

				return new ApiResult<User>
				{
					Result = null,
					ApiCode = ApiCode.UnknownError,
					ErrorMessage = ex.ToString()
				};
			}
		}
	}
}

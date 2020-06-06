using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.Infrastructure;
using GrowingPlants.Infrastructure.Models;
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
				apiResult.Error = ex.ToString();
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
			var stopwatch = Stopwatch.StartNew();
			var apiResult = new ApiResult<bool>();

			try
			{
				_logger.LogInformation("Account registration");
				apiResult.Result = await _userService.Register(user);
				apiResult.Succeed = true;
				_logger.LogInformation("Account registration complete");
			}
			catch (Exception ex)
			{
				apiResult.Succeed = false;
				apiResult.Result = false;
				apiResult.Error = ex.ToString();
				_logger.LogInformation($"Account registration error: {ex}");
			}
			stopwatch.Stop();
			apiResult.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
			_logger.LogInformation($"Execution time: {apiResult.ExecutionTime}ms");
			
			return apiResult;
		}

		[HttpPost]
		[Route("login")]
		public async Task<ApiResult<User>> Login(User user)
		{
			var stopwatch = Stopwatch.StartNew();
			var apiResult = new ApiResult<User>();

			try
			{
				_logger.LogInformation("User login");
				apiResult.Result = await _userService.Login(user.UserName, user.Password);
				apiResult.Succeed = true;
				_logger.LogInformation("User login complete");
			}
			catch (Exception ex)
			{
				apiResult.Succeed = false;
				apiResult.Result = null;
				apiResult.Error = ex.ToString();
				_logger.LogInformation($"User login error: {ex}");
			}
			stopwatch.Stop();
			apiResult.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
			_logger.LogInformation($"Execution time: {apiResult.ExecutionTime}ms");

			return apiResult;
		}
	}
}

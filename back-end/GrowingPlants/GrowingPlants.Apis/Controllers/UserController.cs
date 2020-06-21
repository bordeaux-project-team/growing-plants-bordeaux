using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.Infrastructure.Models;
using GrowingPlants.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GrowingPlants.Apis.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
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

        [Authorize(Roles = Constants.UserRole.Admin)]
        [HttpGet]
        [Route("get-all")]
        public async Task<ApiResult<List<User>>> GetAll()
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Get all users");

                var result = await _userService.GetAll();

                _logger.LogInformation("Get all users complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Get all users error: {ex}");

                return new ApiResult<List<User>>
                {
                    Result = null,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
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

        [AllowAnonymous]
        [HttpPost]
        [Route("google/login")]
        public async Task<ApiResult<User>> GoogleLogin(LoginCredential loginCredential)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();

                _logger.LogInformation("Google login");
                var result = await _userService.GoogleLogin(loginCredential);
                _logger.LogInformation("Google login complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Google login error: {ex}");

                return new ApiResult<User>
                {
                    Result = null,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("forgot-password")]
        public async Task<ApiResult<bool>> ForgotPassword()
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();

                _logger.LogInformation("Forgot password");
                var result = await _userService.ForgotPassword();
                _logger.LogInformation("Forgot password complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Forgot password error: {ex}");

                return new ApiResult<bool>
                {
                    Result = false,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [HttpPut]
        [Route("{id}/update")]
        public async Task<ApiResult<bool>> UpdateUser(int id, User user)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();

                _logger.LogInformation("Update user");

                user.Id = id;

                var result = await _userService.UpdateUser(user);
                _logger.LogInformation("Update user complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Update user error: {ex}");

                return new ApiResult<bool>
                {
                    Result = false,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [HttpPatch]
        [Route("{id}/update/password")]
        public async Task<ApiResult<bool>> UpdateUserPassword(int id, NewPassword newPassword)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();

                _logger.LogInformation("Update user status");

                newPassword.UserId = id;

                var result = await _userService.UpdateUserPassword(newPassword);
                _logger.LogInformation("Update user status complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Update user status error: {ex}");

                return new ApiResult<bool>
                {
                    Result = false,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [Authorize(Roles = Constants.UserRole.Admin)]
        [HttpPatch]
        [Route("{id}/update/status/{status}")]
        public async Task<ApiResult<bool>> UpdateUserStatus(int id, bool status)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();

                _logger.LogInformation("Update user status");

                var result = await _userService.UpdateUserStatus(id, status);
                _logger.LogInformation("Update user status complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Update user status error: {ex}");

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

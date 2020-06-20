﻿using System;
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
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PlantingEnvironmentController : ControllerBase
    {
        private readonly IPlantingEnvironmentService _plantingEnvironmentService;
        private readonly ILogger _logger;

        public PlantingEnvironmentController(ILoggerFactory loggerFactory, IPlantingEnvironmentService plantingEnvironmentService)
        {
            _plantingEnvironmentService = plantingEnvironmentService;
            _logger = loggerFactory.CreateLogger(typeof(PlantingEnvironmentController));
        }

        [HttpGet]
        [Route("User/{userId}")]
        public async Task<ApiResult<List<PlantingEnvironment>>> GetPlantingEnvironmentsByUser(int userId)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Get plantingEnvironments by user");

                var result = await _plantingEnvironmentService.GetPlantingEnvironmentsByUser(userId);

                _logger.LogInformation("Get plantingEnvironments by user complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Get plantingEnvironments by user error: {ex}");

                return new ApiResult<List<PlantingEnvironment>>
                {
                    Result = null,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ApiResult<bool>> InsertPlantingEnvironments(PlantingEnvironment plantingEnvironment)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Insert plantingEnvironment");

                var result = await _plantingEnvironmentService.InsertPlantingEnvironment(plantingEnvironment);

                _logger.LogInformation("Insert plantingEnvironment complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Insert plantingEnvironment error: {ex}");

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
        public async Task<ApiResult<bool>> UpdatePlantingEnvironment(int id, PlantingEnvironment plantingEnvironment)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Update plantingEnvironment");

                plantingEnvironment.Id = id;

                var result = await _plantingEnvironmentService.UpdatePlantingEnvironment(plantingEnvironment);

                _logger.LogInformation("Update plantingEnvironment complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Update plantingEnvironment error: {ex}");

                return new ApiResult<bool>
                {
                    Result = false,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ApiResult<bool>> DeletePlantingEnvironment(int id)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Delete plantingEnvironment");

                var result = await _plantingEnvironmentService.DeletePlantingEnvironment(id);

                _logger.LogInformation("Delete plantingEnvironment complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Delete plantingEnvironment error: {ex}");

                return new ApiResult<bool>
                {
                    Result = false,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [HttpGet]
        [Route("{id}/gardens")]
        public async Task<ApiResult<List<Garden>>> GetGardensByEnvironmentId(int id)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Get gardens by plantingEnvironment Id");

                var result = await _plantingEnvironmentService.GetGardensByEnvironmentId(id);

                _logger.LogInformation("Get gardens by plantingEnvironment Id complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Get gardens by plantingEnvironment Id error: {ex}");

                return new ApiResult<List<Garden>>
                {
                    Result = null,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [HttpGet]
        [Route("gardens/insert-update")]
        public async Task<ApiResult<bool>> InsertUpdateGardens(List<Garden> gardens)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Insert or update gardens");

                var result = await _plantingEnvironmentService.InsertUpdateGardens(gardens);

                _logger.LogInformation("Insert or update gardens complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Insert or update gardens error: {ex}");

                return new ApiResult<bool>
                {
                    Result = false,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [Authorize(Roles = Constants.UserRole.Admin)]
        [HttpPost]
        [Route("humidity/insert")]
        public async Task<ApiResult<bool>> InsertHumidityList(IEnumerable<Humidity> humidityList)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Insert humidityList");

                var result = await _plantingEnvironmentService.InsertHumidityList(humidityList?.ToList());

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

        [Authorize(Roles = Constants.UserRole.Admin)]
        [HttpPut]
        [Route("humidity/{id}/update")]
        public async Task<ApiResult<bool>> UpdateHumidity(int id, Humidity humidity)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Update humidity");

                humidity.Id = id;

                var result = await _plantingEnvironmentService.UpdateHumidity(humidity);

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

        [HttpPost]
        [Route("light/insert")]
        public async Task<ApiResult<bool>> InsertLights(IEnumerable<Light> lights)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Insert lights");

                var result = await _plantingEnvironmentService.InsertLights(lights?.ToList());

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
        [Route("light/{id}/update")]
        public async Task<ApiResult<bool>> UpdateLight(int id, Light light)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Update light");

                light.Id = id;

                var result = await _plantingEnvironmentService.UpdateLight(light);

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

        [Authorize(Roles = Constants.UserRole.Admin)]
        [HttpPost]
        [Route("temperature/insert")]
        public async Task<ApiResult<bool>> InsertTemperatures(IEnumerable<Temperature> temperatures)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Insert temperatures");

                var result = await _plantingEnvironmentService.InsertTemperatures(temperatures?.ToList());

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

        [Authorize(Roles = Constants.UserRole.Admin)]
        [HttpPut]
        [Route("temperature/{id}/update")]
        public async Task<ApiResult<bool>> UpdateTemperature(int id, Temperature temperature)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Update temperature");

                temperature.Id = id;

                var result = await _plantingEnvironmentService.UpdateTemperature(temperature);

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

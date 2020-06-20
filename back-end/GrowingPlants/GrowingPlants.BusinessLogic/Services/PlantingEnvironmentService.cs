using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.BusinessLogic.UnitOfWorks;
using GrowingPlants.Infrastructure.Models;
using GrowingPlants.Infrastructure.Utilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GrowingPlants.BusinessLogic.Services
{
    public class PlantingEnvironmentService : IPlantingEnvironmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public PlantingEnvironmentService(ILoggerFactory loggerFactory, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = loggerFactory.CreateLogger(typeof(PlantingEnvironmentService));
        }

        public Task<ApiResult<List<PlantingEnvironment>>> GetPlantingEnvironmentsByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<bool>> InsertPlantingEnvironment(PlantingEnvironment plantingEnvironment)
        {
            if (plantingEnvironment == null)
            {
                _logger.LogError("plantingEnvironment is null");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NullObject,
                    ErrorMessage = "plantingEnvironment inputted is null",
                    Result = false
                };
            }

            if (plantingEnvironment.UserId == null)
            {
                _logger.LogError($"User id is null for {JsonConvert.SerializeObject(plantingEnvironment)}");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NullObject,
                    ErrorMessage = "User id is null",
                    Result = false
                };
            }

            _logger.LogInformation($"Insert planting environment: {JsonConvert.SerializeObject(plantingEnvironment)}");

            var insertResult = await _unitOfWork.PlantingEnvironmentRepository.Insert(plantingEnvironment);

            return new ApiResult<bool>
            {
                Result = insertResult,
                ApiCode = ApiCode.Success
            };
        }

        public async Task<ApiResult<bool>> UpdatePlantingEnvironment(PlantingEnvironment plantingEnvironment)
        {
            if (plantingEnvironment == null)
            {
                _logger.LogError("plantingEnvironment is null");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NullObject,
                    ErrorMessage = "plantingEnvironment inputted is null",
                    Result = false
                };
            }

            _logger.LogInformation($"plantingEnvironment to update: {JsonConvert.SerializeObject(plantingEnvironment)}");

            var existing = await _unitOfWork.PlantingEnvironmentRepository.GetById(plantingEnvironment.Id);
            if (existing == null)
            {
                _logger.LogError($"plantingEnvironment not found with id: {plantingEnvironment.Id}");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NotFound,
                    ErrorMessage = $"plantingEnvironment not found with id: {plantingEnvironment.Id}",
                    Result = false
                };
            }

            existing.Name = plantingEnvironment.Name;
            existing.CountryId = plantingEnvironment.CountryId;
            existing.HumidityId = plantingEnvironment.HumidityId;
            existing.TemperatureId = plantingEnvironment.TemperatureId;
            existing.ExposureTime = plantingEnvironment.ExposureTime;
            existing.Length = plantingEnvironment.Length;
            existing.Width = plantingEnvironment.Width;
            existing.LightId = plantingEnvironment.LightId;
            existing.Light = plantingEnvironment.Light;
            existing.Type = plantingEnvironment.Type;
            existing.UpdatedAt = DateTime.UtcNow;

            var result = await _unitOfWork.PlantingEnvironmentRepository.Update(existing);
            return new ApiResult<bool>
            {
                Result = result,
                ApiCode = ApiCode.Success
            };
        }

        public async Task<ApiResult<bool>> DeletePlantingEnvironment(int id)
        {
            var toDelete = await _unitOfWork.PlantingEnvironmentRepository.GetById(id);
            if (toDelete == null)
            {
                _logger.LogError($"plantingEnvironment not found with id: {id}");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NotFound,
                    ErrorMessage = $"plantingEnvironment not found with id: {id}",
                    Result = false
                };
            }
            _logger.LogInformation($"Delete plantingEnvironment with Id: {id} - {JsonConvert.SerializeObject(toDelete)}");
            var deleteResult = await _unitOfWork.PlantingEnvironmentRepository.Delete(toDelete);
            return new ApiResult<bool>
            {
                Result = deleteResult,
                ApiCode = ApiCode.Success
            };
        }

        public async Task<ApiResult<List<PlantingSpot>>> GetPlantingSpotsByEnvironmentId(int id)
        {
            _logger.LogInformation($"Environment id {id}");

            var plantingSpots = await _unitOfWork.PlantingSpotRepository.GetPlantingSpotsByEnvironmentId(id);

            if (plantingSpots == null || !plantingSpots.Any())
            {
                return new ApiResult<List<PlantingSpot>>
                {
                    ApiCode = ApiCode.NotFound,
                    Result = null,
                    ErrorMessage = $"PlantingSpots not found with environment id: {id}"
                };
            }

            return new ApiResult<List<PlantingSpot>>
            {
                Result = plantingSpots,
                ApiCode = ApiCode.Success
            };
        }

        public async Task<ApiResult<bool>> InsertUpdatePlantingSpots(int environmentId, List<PlantingSpot> plantingSpots)
        {
            if (plantingSpots == null || !plantingSpots.Any())
            {
                _logger.LogError("PlantingSpots is empty");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.EmptyOrNullListObjects,
                    ErrorMessage = "PlantingSpots inputted is empty",
                    Result = false
                };
            }
            _logger.LogInformation($"Insert or update plantingSpots for {environmentId} - {JsonConvert.SerializeObject(plantingSpots)}");
            var existing = await _unitOfWork.PlantingSpotRepository.GetPlantingSpotsByEnvironmentId(environmentId);

            if (existing == null || !existing.Any())
            {
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NotFound,
                    Result = false,
                    ErrorMessage = $"PlantingSpots not found with environment id: {environmentId}"
                };
            }

            var toInsert = plantingSpots
                .Where(x => existing.All(y => y.Position != x.Position))
                .Select(x =>
                {
                    x.CreatedAt = DateTime.UtcNow;
                    return x;
                })
                .ToList();

            var toUpdate = new List<PlantingSpot>();

            foreach (var existingSpot in existing)
            {
                var spot = plantingSpots.FirstOrDefault(x => x.Position == existingSpot.Position);
                if (spot == null) continue;

                existingSpot.TreeId = spot.TreeId;
                existingSpot.Amount = spot.Amount;
                existingSpot.UpdatedAt = DateTime.UtcNow;
                toUpdate.Add(existingSpot);
            }

            var toDelete = existing.Where(x => plantingSpots.All(y => x.Position != y.Position)).ToList();
            _logger.LogInformation($"To insert: {toInsert.Count} | to update: {toUpdate.Count} | to delete: {toDelete.Count}");

            var toInsertTask = _unitOfWork.PlantingSpotRepository.Insert(toInsert);
            var toUpdateTask = _unitOfWork.PlantingSpotRepository.Update(toUpdate);
            var toDeleteTask = _unitOfWork.PlantingSpotRepository.Delete(toDelete);
            await Task.WhenAll(toInsertTask, toUpdateTask, toDeleteTask);

            return new ApiResult<bool>
            {
                Result = true,
                ApiCode = ApiCode.Success
            };
        }

        public async Task<ApiResult<bool>> InsertHumidityList(List<Humidity> humidityList)
        {
            if (humidityList == null || !humidityList.Any())
            {
                _logger.LogError("HumidityList is empty");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.EmptyOrNullListObjects,
                    ErrorMessage = "HumidityList inputted is empty",
                    Result = false
                };
            }

            _logger.LogInformation($"HumidityList to insert: {JsonConvert.SerializeObject(humidityList)}");

            humidityList.ForEach(x => x.CreatedAt = DateTime.UtcNow);

            var result = await _unitOfWork.HumidityRepository.Insert(humidityList);

            return new ApiResult<bool>
            {
                ApiCode = ApiCode.Success,
                Result = result
            };
        }

        public async Task<ApiResult<bool>> UpdateHumidity(Humidity humidity)
        {
            if (humidity == null)
            {
                _logger.LogError("Humidity is null");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NullObject,
                    ErrorMessage = "Humidity inputted is null",
                    Result = false
                };
            }

            _logger.LogInformation($"Humidity to update: {JsonConvert.SerializeObject(humidity)}");

            var existing = await _unitOfWork.HumidityRepository.GetById(humidity.Id);
            if (existing == null)
            {
                _logger.LogError($"Humidity not found with id: {humidity.Id}");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NotFound,
                    ErrorMessage = $"Humidity not found with id: {humidity.Id}",
                    Result = false
                };
            }

            existing.Name = humidity.Name;
            existing.FromUnit = humidity.FromUnit;
            existing.MeasurementUnitId = humidity.MeasurementUnitId;
            existing.ToUnit = humidity.ToUnit;
            existing.UpdatedAt = DateTime.UtcNow;

            var result = await _unitOfWork.HumidityRepository.Update(existing);
            return new ApiResult<bool>
            {
                Result = result,
                ApiCode = ApiCode.Success
            };
        }

        public async Task<ApiResult<bool>> InsertLights(List<Light> lights)
        {
            if (lights == null || !lights.Any())
            {
                _logger.LogError("Lights is empty");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.EmptyOrNullListObjects,
                    ErrorMessage = "Lights inputted is empty",
                    Result = false
                };
            }

            _logger.LogInformation($"Lights to insert: {JsonConvert.SerializeObject(lights)}");

            lights.ForEach(x => x.CreatedAt = DateTime.UtcNow);

            var result = await _unitOfWork.LightRepository.Insert(lights);

            return new ApiResult<bool>
            {
                ApiCode = ApiCode.Success,
                Result = result
            };
        }

        public async Task<ApiResult<bool>> UpdateLight(Light light)
        {
            if (light == null)
            {
                _logger.LogError("Light is null");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NullObject,
                    ErrorMessage = "Light inputted is null",
                    Result = false
                };
            }

            _logger.LogInformation($"Light to update: {JsonConvert.SerializeObject(light)}");

            var existing = await _unitOfWork.LightRepository.GetById(light.Id);
            if (existing == null)
            {
                _logger.LogError($"Light not found with id: {light.Id}");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NotFound,
                    ErrorMessage = $"Light not found with id: {light.Id}",
                    Result = false
                };
            }

            existing.Name = light.Name;
            existing.MeasurementUnitId = light.MeasurementUnitId;
            existing.FromUnit = light.FromUnit;
            existing.ToUnit = light.ToUnit;
            existing.UpdatedAt = DateTime.UtcNow;

            var result = await _unitOfWork.LightRepository.Update(existing);
            return new ApiResult<bool>
            {
                Result = result,
                ApiCode = ApiCode.Success
            };
        }

        public async Task<ApiResult<bool>> InsertTemperatures(List<Temperature> temperatures)
        {
            if (temperatures == null || !temperatures.Any())
            {
                _logger.LogError("Temperatures is empty");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.EmptyOrNullListObjects,
                    ErrorMessage = "Temperatures inputted is empty",
                    Result = false
                };
            }

            _logger.LogInformation($"Temperatures to insert: {JsonConvert.SerializeObject(temperatures)}");

            temperatures.ForEach(x => x.CreatedAt = DateTime.UtcNow);

            var result = await _unitOfWork.TemperatureRepository.Insert(temperatures);

            return new ApiResult<bool>
            {
                ApiCode = ApiCode.Success,
                Result = result
            };
        }

        public async Task<ApiResult<bool>> UpdateTemperature(Temperature temperature)
        {
            if (temperature == null)
            {
                _logger.LogError("Temperature is null");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NullObject,
                    ErrorMessage = "Temperature inputted is null",
                    Result = false
                };
            }

            _logger.LogInformation($"Temperature to update: {JsonConvert.SerializeObject(temperature)}");

            var existing = await _unitOfWork.TemperatureRepository.GetById(temperature.Id);
            if (existing == null)
            {
                _logger.LogError($"Temperature not found with id: {temperature.Id}");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NotFound,
                    ErrorMessage = $"Temperature not found with id: {temperature.Id}",
                    Result = false
                };
            }

            existing.Name = temperature.Name;
            existing.MeasurementUnitId = temperature.MeasurementUnitId;
            existing.FromDegree = temperature.FromDegree;
            existing.ToDegree = temperature.ToDegree;
            existing.UpdatedAt = DateTime.UtcNow;

            var result = await _unitOfWork.TemperatureRepository.Update(existing);
            return new ApiResult<bool>
            {
                Result = result,
                ApiCode = ApiCode.Success
            };
        }
    }
}

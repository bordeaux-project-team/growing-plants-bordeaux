﻿using GrowingPlants.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowingPlants.BusinessLogic.IServices
{
    public interface IPlantingEnvironmentService
    {
        Task<ApiResult<bool>> InsertPlantingEnvironment(PlantingEnvironment plantingEnvironment);
        Task<ApiResult<bool>> UpdatePlantingEnvironment(PlantingEnvironment plantingEnvironment);
        Task<ApiResult<bool>> InsertLights(List<Light> lights);
        Task<ApiResult<bool>> UpdateLight(Light light);
        Task<ApiResult<bool>> InsertTemperatures(List<Temperature> temperatures);
        Task<ApiResult<bool>> UpdateTemperature(Temperature temperature);
        Task<ApiResult<bool>> InsertHumidityList(List<Humidity> humidityList);
        Task<ApiResult<bool>> UpdateHumidity(Humidity humidity);
        Task<ApiResult<bool>> DeletePlantingEnvironment(int id);
        Task<ApiResult<bool>> DeletePlantingSpot(int id);
        Task<ApiResult<List<PlantingEnvironment>>> GetPlantingEnvironmentsByUser(int userId);
        Task<ApiResult<List<PlantingSpot>>> GetPlantingSpotsByEnvironmentId(int id);
        Task<ApiResult<bool>> InsertUpdatePlantingSpots(int environmentId, List<PlantingSpot> plantingSpots);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using GrowingPlants.Infrastructure.Models;

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
        Task<ApiResult<List<PlantingEnvironment>>> GetPlantingEnvironmentsByUser(int userId);
        Task<ApiResult<List<Garden>>> GetGardensByEnvironmentId(int id);
        Task<ApiResult<bool>> InsertUpdateGardens(List<Garden> gardens);
    }
}

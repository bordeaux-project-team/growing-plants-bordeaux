using GrowingPlants.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowingPlants.BusinessLogic.IServices
{
    public interface IPlantingProcessService
    {
        Task<ApiResult<bool>> InsertPlantingProcesses(List<PlantingProcess> plantingProcesses);
        Task<ApiResult<bool>> InsertPlantingProcess(PlantingProcess plantingProcess);
        Task<ApiResult<bool>> UpdatePlantingProcess(PlantingProcess plantingProcess);
        Task<ApiResult<bool>> InsertProcessSteps(int processId, List<ProcessStep> processSteps);
        Task<ApiResult<bool>> UpdateProcessStep(ProcessStep processStep);
        Task<ApiResult<bool>> InsertPlantingAction(PlantingAction plantingAction);
        Task<ApiResult<bool>> UpdatePlantingAction(PlantingAction plantingAction);
        Task<ApiResult<bool>> DeletePlantingAction(int id);
        Task<ApiResult<PlantingProcess>> GetPlantingProcessAtSpot(int userId);
    }
}

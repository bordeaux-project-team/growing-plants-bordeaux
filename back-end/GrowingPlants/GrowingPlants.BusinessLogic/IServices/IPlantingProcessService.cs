using System.Collections.Generic;
using System.Threading.Tasks;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.BusinessLogic.IServices
{
	public interface IPlantingProcessService
	{
        Task<ApiResult<bool>> InsertPlantingProcesses(List<PlantingProcess> plantingProcesses);
        Task<ApiResult<bool>> UpdatePlantingProcess(PlantingProcess plantingProcess);
        Task<ApiResult<bool>> InsertProcessSteps(int processId, List<ProcessStep> processSteps);
        Task<ApiResult<bool>> UpdateProcessStep(ProcessStep processStep);
    }
}

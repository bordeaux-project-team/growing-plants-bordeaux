using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.BusinessLogic.UnitOfWorks;
using GrowingPlants.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowingPlants.BusinessLogic.Services
{
    public class PlantingProcessService : IPlantingProcessService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public PlantingProcessService(ILoggerFactory loggerFactory, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = loggerFactory.CreateLogger(typeof(PlantingProcessService));
        }

        public Task<ApiResult<bool>> InsertPlantingProcesses(List<PlantingProcess> plantingProcesses)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResult<bool>> UpdatePlantingProcess(PlantingProcess plantingProcess)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResult<bool>> InsertProcessSteps(int processId, List<ProcessStep> processSteps)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResult<bool>> UpdateProcessStep(ProcessStep processStep)
        {
            throw new System.NotImplementedException();
        }
    }
}

using System;
using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.BusinessLogic.UnitOfWorks;
using GrowingPlants.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrowingPlants.Infrastructure.Utilities;
using Newtonsoft.Json;

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

        public async Task<ApiResult<bool>> InsertPlantingProcess(PlantingProcess plantingProcess)
        {
            if (plantingProcess == null)
            {
                _logger.LogError("plantingProcess is null");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NullObject,
                    ErrorMessage = "plantingProcess is null",
                    Result = false
                };
            }

            _logger.LogInformation($"Planting process to insert: {JsonConvert.SerializeObject(plantingProcess)}");

            var processSteps = new List<ProcessStep>();
            for (var date = plantingProcess.StartDate.Date;
                date <= plantingProcess.HarvestDate.Date;
                date = date.AddDays(1))
            {
                processSteps.Add(new ProcessStep
                {
                    StartDate = date.Date,
                    CreatedAt = DateTime.UtcNow,
                });
            }

            plantingProcess.CreatedAt = DateTime.UtcNow;
            plantingProcess.ProcessSteps = processSteps;

            var result = await _unitOfWork.PlantingProcessRepository.Insert(plantingProcess);

            return new ApiResult<bool>
            {
                ApiCode = ApiCode.Success,
                Result = result
            };
        }

        public async Task<ApiResult<bool>> InsertPlantingAction(PlantingAction plantingAction)
        {
            if (plantingAction == null)
            {
                _logger.LogError("plantingAction is null");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NullObject,
                    ErrorMessage = "plantingAction is null",
                    Result = false
                };
            }

            _logger.LogInformation($"Planting action to insert: {JsonConvert.SerializeObject(plantingAction)}");

            plantingAction.CreatedAt = DateTime.UtcNow;

            var result = await _unitOfWork.PlantingActionRepository.Insert(plantingAction);

            return new ApiResult<bool>
            {
                ApiCode = ApiCode.Success,
                Result = result
            };
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

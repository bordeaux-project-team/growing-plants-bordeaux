using System;
using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.BusinessLogic.UnitOfWorks;
using GrowingPlants.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrowingPlants.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ApiResult<PlantingProcess>> GetPlantingProcessAtSpot(int spotId)
        {
            return new ApiResult<PlantingProcess>
            {
                ApiCode = ApiCode.Success,
                Result = await _unitOfWork.PlantingProcessRepository.GetBySpotId(spotId)
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

        public async Task<ApiResult<bool>> UpdatePlantingAction(PlantingAction plantingAction)
        {
            if (plantingAction == null)
            {
                _logger.LogError("plantingAction is null");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NullObject,
                    ErrorMessage = "plantingProcess inputted is null",
                    Result = false
                };
            }

            _logger.LogInformation($"plantingAction to update: {JsonConvert.SerializeObject(plantingAction)}");

            var existing = await _unitOfWork.PlantingActionRepository.GetFirstOrDefault(x => x.Id == plantingAction.Id);

            if (existing == null)
            {
                _logger.LogError($"plantingAction not found with id: {plantingAction.Id}");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NotFound,
                    ErrorMessage = $"plantingAction not found with id: {plantingAction.Id}",
                    Result = false
                };
            }

            existing.Description = plantingAction.Description;
            existing.ActionTime = plantingAction.ActionTime;
            existing.Amount = plantingAction.Amount;
            existing.Name = plantingAction.Name;
            existing.Status = plantingAction.Status;

            var result = await _unitOfWork.PlantingActionRepository.Update(existing);
            return new ApiResult<bool>
            {
                Result = result,
                ApiCode = ApiCode.Success
            };
        }

        public async Task<ApiResult<bool>> DeletePlantingAction(int id)
        {
            var toDelete = await _unitOfWork.PlantingActionRepository.GetFirstOrDefault(x => x.Id == id);
            if (toDelete == null)
            {
                _logger.LogError($"plantingAction not found with id: {id}");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NotFound,
                    ErrorMessage = $"plantingAction not found with id: {id}",
                    Result = false
                };
            }
            _logger.LogInformation($"Delete plantingAction with Id: {id} - {JsonConvert.SerializeObject(toDelete)}");
            var deleteResult = await _unitOfWork.PlantingActionRepository.Delete(toDelete);
            return new ApiResult<bool>
            {
                Result = deleteResult,
                ApiCode = ApiCode.Success
            };
        }

        public Task<ApiResult<bool>> InsertPlantingProcesses(List<PlantingProcess> plantingProcesses)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ApiResult<bool>> UpdatePlantingProcess(PlantingProcess plantingProcess)
        {
            if (plantingProcess == null)
            {
                _logger.LogError("plantingProcess is null");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NullObject,
                    ErrorMessage = "plantingProcess inputted is null",
                    Result = false
                };
            }

            _logger.LogInformation($"plantingProcess to update: {JsonConvert.SerializeObject(plantingProcess)}");

            var existing = await _unitOfWork.PlantingProcessRepository
                .GetQueryable()
                .Include(x => x.ProcessSteps)
                .FirstOrDefaultAsync(x => x.Id == plantingProcess.Id);

            if (existing == null)
            {
                _logger.LogError($"plantingProcess not found with id: {plantingProcess.Id}");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NotFound,
                    ErrorMessage = $"plantingProcess not found with id: {plantingProcess.Id}",
                    Result = false
                };
            }

            existing.FloweringDate = plantingProcess.FloweringDate;
            existing.GerminationDate = plantingProcess.GerminationDate;
            existing.VegetativeDate = plantingProcess.VegetativeDate;
            existing.StartDate = plantingProcess.StartDate;
            existing.HarvestDate = plantingProcess.HarvestDate;
            existing.UserId = plantingProcess.UserId;
            existing.TreeId = plantingProcess.TreeId;
            existing.UpdatedAt = DateTime.UtcNow;

            for (var date = plantingProcess.StartDate.Date;
                date <= plantingProcess.HarvestDate.Date;
                date = date.AddDays(1))
            {
                if (existing.ProcessSteps.Any(x => x.StartDate == date)) continue;

                existing.ProcessSteps.Add(new ProcessStep
                {
                    StartDate = date.Date,
                    CreatedAt = DateTime.UtcNow,
                });
            }

            existing.ProcessSteps = existing.ProcessSteps.OrderBy(x => x.StartDate).ToList();

            var result = await _unitOfWork.PlantingProcessRepository.Update(existing);
            return new ApiResult<bool>
            {
                Result = result,
                ApiCode = ApiCode.Success
            };
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

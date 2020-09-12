using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.Infrastructure.Models;
using GrowingPlants.Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace GrowingPlants.Apis.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/planting-process")]
    public class PlantingProcessController : ControllerBase
    {
        private readonly IPlantingProcessService _plantingProcessService;
        private readonly ILogger _logger;

        public PlantingProcessController(ILoggerFactory loggerFactory, IPlantingProcessService plantingProcessService)
        {
            _plantingProcessService = plantingProcessService;
            _logger = loggerFactory.CreateLogger(typeof(PlantingProcessController));
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ApiResult<bool>> InsertPlantingProcess(PlantingProcess plantingProcess)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Insert plantingProcess");

                var result = await _plantingProcessService.InsertPlantingProcess(plantingProcess);

                _logger.LogInformation("Insert plantingProcess complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Insert plantingProcess error: {ex}");

                return new ApiResult<bool>
                {
                    Result = false,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [HttpGet]
        [Route("planting-spot/{spotId}")]
        public async Task<ApiResult<PlantingProcess>> GetPlantingProcessAtSpot(int spotId)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation($"Get plantingProcess by spotId: {spotId}");

                var result = await _plantingProcessService.GetPlantingProcessAtSpot(spotId);

                _logger.LogInformation("Get plantingProcess complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Get plantingProcesses error - {spotId}: {ex}");

                return new ApiResult<PlantingProcess>
                {
                    Result = null,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [HttpPut]
        [Route("{id}/update")]
        public async Task<ApiResult<bool>> UpdatePlantingProcess(int id, PlantingProcess plantingProcess)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Update plantingProcess");

                plantingProcess.Id = id;

                var result = await _plantingProcessService.UpdatePlantingProcess(plantingProcess);

                _logger.LogInformation("Update plantingProcess complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Update plantingProcess error: {ex}");

                return new ApiResult<bool>
                {
                    Result = false,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [HttpPost]
        [Route("{processId}/process-step/insert")]
        public async Task<ApiResult<bool>> InsertProcessSteps(int processId, IEnumerable<ProcessStep> processSteps)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Insert processSteps");

                var result = await _plantingProcessService.InsertProcessSteps(processId, processSteps?.ToList());

                _logger.LogInformation("Insert processSteps complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Insert processSteps error: {ex}");

                return new ApiResult<bool>
                {
                    Result = false,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [HttpPut]
        [Route("process-step/{id}/update")]
        public async Task<ApiResult<bool>> UpdateProcessStep(int id, ProcessStep processStep)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Update processStep");

                processStep.Id = id;

                var result = await _plantingProcessService.UpdateProcessStep(processStep);

                _logger.LogInformation("Update processStep complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Update processStep error: {ex}");

                return new ApiResult<bool>
                {
                    Result = false,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [HttpPost]
        [Route("planting-action/insert")]
        public async Task<ApiResult<bool>> InsertPlantingAction(PlantingAction plantingAction)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Insert plantingAction");

                var result = await _plantingProcessService.InsertPlantingAction(plantingAction);

                _logger.LogInformation("Insert plantingAction complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Insert plantingAction error: {ex}");

                return new ApiResult<bool>
                {
                    Result = false,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [HttpPut]
        [Route("planting-action/{id}/update")]
        public async Task<ApiResult<bool>> UpdatePlantingAction(int id, PlantingAction plantingAction)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Update plantingAction");

                plantingAction.Id = id;

                var result = await _plantingProcessService.UpdatePlantingAction(plantingAction);

                _logger.LogInformation("Update plantingAction complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Update plantingAction error: {ex}");

                return new ApiResult<bool>
                {
                    Result = false,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [HttpDelete]
        [Route("planting-action/{id}/delete")]
        public async Task<ApiResult<bool>> DeletePlantingAction(int id)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Delete plantingAction");

                var result = await _plantingProcessService.DeletePlantingAction(id);

                _logger.LogInformation("Delete plantingAction complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Delete plantingAction error: {ex}");

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

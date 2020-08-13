using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.Infrastructure.Models;
using GrowingPlants.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GrowingPlants.Apis.Controllers
{
    [Authorize(Roles = Constants.UserRole.Admin)]
    [ApiController]
    [Route("api/measurement-unit")]
    public class MeasurementUnitController : ControllerBase
    {
        private readonly IMeasurementUnitService _measurementUnitService;
        private readonly ILogger _logger;

        public MeasurementUnitController(ILoggerFactory loggerFactory, IMeasurementUnitService measurementUnitService)
        {
            _measurementUnitService = measurementUnitService;
            _logger = loggerFactory.CreateLogger(typeof(MeasurementUnitController));
        }


        [HttpPost]
        [Route("insert")]
        public async Task<ApiResult<bool>> InsertMeasurementUnits(IEnumerable<MeasurementUnit> measurementUnits)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Insert measurementUnits");

                var result = await _measurementUnitService.InsertMeasurementUnits(measurementUnits?.ToList());

                _logger.LogInformation("Insert measurementUnits complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Insert measurementUnits error: {ex}");

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
        public async Task<ApiResult<bool>> UpdateMeasurementUnit(int id, MeasurementUnit measurementUnit)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Update measurementUnit");

                measurementUnit.Id = id;

                var result = await _measurementUnitService.UpdateMeasurementUnit(measurementUnit);

                _logger.LogInformation("Update measurementUnit complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Update measurementUnit error: {ex}");

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

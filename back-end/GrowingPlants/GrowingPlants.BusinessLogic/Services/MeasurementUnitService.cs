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
	public class MeasurementUnitService : IMeasurementUnitService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger _logger;

		public MeasurementUnitService(ILoggerFactory loggerFactory, IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_logger = loggerFactory.CreateLogger(typeof(MeasurementUnitService));
		}

		public async Task<ApiResult<bool>> InsertMeasurementUnits(List<MeasurementUnit> measurementUnits)
		{
			if (measurementUnits == null || !measurementUnits.Any())
			{
				_logger.LogError("MeasurementUnits is empty");
				return new ApiResult<bool>
				{
					ApiCode = ApiCode.EmptyOrNullListObjects,
					ErrorMessage = "MeasurementUnits inputted is empty",
					Result = false
				};
			}

			_logger.LogInformation($"MeasurementUnits to insert: {JsonConvert.SerializeObject(measurementUnits)}");

			measurementUnits.ForEach(x => x.CreatedAt = DateTime.UtcNow);

			var result = await _unitOfWork.MeasurementUnitRepository.Insert(measurementUnits);

			return new ApiResult<bool>
			{
				ApiCode = ApiCode.Success,
				Result = result
			};
		}

		public async Task<ApiResult<bool>> UpdateMeasurementUnit(MeasurementUnit measurementUnit)
		{
			if (measurementUnit == null)
			{
				_logger.LogError("MeasurementUnit is null");
				return new ApiResult<bool>
				{
					ApiCode = ApiCode.NullObject,
					ErrorMessage = "MeasurementUnit inputted is null",
					Result = false
				};
			}

			_logger.LogInformation($"MeasurementUnit to update: {JsonConvert.SerializeObject(measurementUnit)}");

			var existing = await _unitOfWork.MeasurementUnitRepository.GetById(measurementUnit.Id);
			if (existing == null)
			{
				_logger.LogError($"MeasurementUnit not found with id: {measurementUnit.Id}");
				return new ApiResult<bool>
				{
					ApiCode = ApiCode.NotFound,
					ErrorMessage = $"MeasurementUnit not found with id: {measurementUnit.Id}",
					Result = false
				};
			}

			existing.Name = measurementUnit.Name;
			existing.Description = measurementUnit.Description;
			existing.UpdatedAt = DateTime.UtcNow;

			var result = await _unitOfWork.MeasurementUnitRepository.Update(existing);
			return new ApiResult<bool>
			{
				Result = result,
				ApiCode = ApiCode.Success
			};
		}
	}
}

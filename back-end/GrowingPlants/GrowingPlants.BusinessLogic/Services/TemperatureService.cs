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
	public class TemperatureService : ITemperatureService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger _logger;

		public TemperatureService(ILoggerFactory loggerFactory, IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_logger = loggerFactory.CreateLogger(typeof(TemperatureService));
		}

		public async Task<ApiResult<bool>> InsertTemperatures(List<Temperature> temperatures)
		{
			if (temperatures == null || !temperatures.Any())
			{
				_logger.LogError("Temperatures is empty");
				return new ApiResult<bool>
				{
					ApiCode = ApiCode.EmptyOrNullListObjects,
					ErrorMessage = "Temperatures inputted is empty",
					Result = false
				};
			}

			_logger.LogInformation($"Temperatures to insert: {JsonConvert.SerializeObject(temperatures)}");

			temperatures.ForEach(x => x.CreatedAt = DateTime.UtcNow);

			var result = await _unitOfWork.TemperatureRepository.Insert(temperatures);

			return new ApiResult<bool>
			{
				ApiCode = ApiCode.Success,
				Result = result
			};
		}

		public async Task<ApiResult<bool>> UpdateTemperature(Temperature temperature)
		{
			if (temperature == null)
			{
				_logger.LogError("Temperature is null");
				return new ApiResult<bool>
				{
					ApiCode = ApiCode.NullObject,
					ErrorMessage = "Temperature inputted is null",
					Result = false
				};
			}

			_logger.LogInformation($"Temperature to update: {JsonConvert.SerializeObject(temperature)}");

			var existing = await _unitOfWork.TemperatureRepository.GetById(temperature.Id);
			if (existing == null)
			{
				_logger.LogError($"Temperature not found with id: {temperature.Id}");
				return new ApiResult<bool>
				{
					ApiCode = ApiCode.NotFound,
					ErrorMessage = $"Temperature not found with id: {temperature.Id}",
					Result = false
				};
			}

			existing.Name = temperature.Name;
			existing.MeasurementUnitId = temperature.MeasurementUnitId;
			existing.FromDegree = temperature.FromDegree;
			existing.ToDegree = temperature.ToDegree;
			existing.UpdatedAt = DateTime.UtcNow;

			var result = await _unitOfWork.TemperatureRepository.Update(existing);
			return new ApiResult<bool>
			{
				Result = result,
				ApiCode = ApiCode.Success
			};
		}
	}
}

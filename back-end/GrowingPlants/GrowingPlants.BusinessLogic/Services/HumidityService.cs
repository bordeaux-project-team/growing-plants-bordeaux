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
	public class HumidityService : IHumidityService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger _logger;

		public HumidityService(ILoggerFactory loggerFactory, IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_logger = loggerFactory.CreateLogger(typeof(HumidityService));
		}

		public async Task<ApiResult<bool>> InsertHumidityList(List<Humidity> humidityList)
		{
			if (humidityList == null || !humidityList.Any())
			{
				_logger.LogError("HumidityList is empty");
				return new ApiResult<bool>
				{
					ApiCode = ApiCode.EmptyOrNullListObjects,
					ErrorMessage = "HumidityList inputted is empty",
					Result = false
				};
			}

			_logger.LogInformation($"HumidityList to insert: {JsonConvert.SerializeObject(humidityList)}");

			humidityList.ForEach(x => x.CreatedAt = DateTime.UtcNow);

			var result = await _unitOfWork.HumidityRepository.Insert(humidityList);

			return new ApiResult<bool>
			{
				ApiCode = ApiCode.Success,
				Result = result
			};
		}

		public async Task<ApiResult<bool>> UpdateHumidity(Humidity humidity)
		{
			if (humidity == null)
			{
				_logger.LogError("Humidity is null");
				return new ApiResult<bool>
				{
					ApiCode = ApiCode.NullObject,
					ErrorMessage = "Humidity inputted is null",
					Result = false
				};
			}

			_logger.LogInformation($"Humidity to update: {JsonConvert.SerializeObject(humidity)}");

			var existing = await _unitOfWork.HumidityRepository.GetById(humidity.Id);
			if (existing == null)
			{
				_logger.LogError($"Humidity not found with id: {humidity.Id}");
				return new ApiResult<bool>
				{
					ApiCode = ApiCode.NotFound,
					ErrorMessage = $"Humidity not found with id: {humidity.Id}",
					Result = false
				};
			}

			existing.Name = humidity.Name;
			existing.FromUnit = humidity.FromUnit;
			existing.MeasurementUnitId = humidity.MeasurementUnitId;
			existing.ToUnit = humidity.ToUnit;
			existing.UpdatedAt = DateTime.UtcNow;

			var result = await _unitOfWork.HumidityRepository.Update(existing);
			return new ApiResult<bool>
			{
				Result = result,
				ApiCode = ApiCode.Success
			};
		}
	}
}

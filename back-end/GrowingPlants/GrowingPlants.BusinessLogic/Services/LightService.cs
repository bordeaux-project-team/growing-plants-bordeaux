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
	public class LightService : ILightService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger _logger;

		public LightService(ILoggerFactory loggerFactory, IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_logger = loggerFactory.CreateLogger(typeof(LightService));
		}

		public async Task<ApiResult<bool>> InsertLights(List<Light> lights)
		{
			if (lights == null || !lights.Any())
			{
				_logger.LogError("Lights is empty");
				return new ApiResult<bool>
				{
					ApiCode = ApiCode.EmptyOrNullListObjects,
					ErrorMessage = "Lights inputted is empty",
					Result = false
				};
			}

			_logger.LogInformation($"Lights to insert: {JsonConvert.SerializeObject(lights)}");

			lights.ForEach(x => x.CreatedAt = DateTime.UtcNow);

			var result = await _unitOfWork.LightRepository.Insert(lights);

			return new ApiResult<bool>
			{
				ApiCode = ApiCode.Success,
				Result = result
			};
		}

		public async Task<ApiResult<bool>> UpdateLight(Light light)
		{
			if (light == null)
			{
				_logger.LogError("Light is null");
				return new ApiResult<bool>
				{
					ApiCode = ApiCode.NullObject,
					ErrorMessage = "Light inputted is null",
					Result = false
				};
			}

			_logger.LogInformation($"Light to update: {JsonConvert.SerializeObject(light)}");

			var existing = await _unitOfWork.LightRepository.GetById(light.Id);
			if (existing == null)
			{
				_logger.LogError($"Light not found with id: {light.Id}");
				return new ApiResult<bool>
				{
					ApiCode = ApiCode.NotFound,
					ErrorMessage = $"Light not found with id: {light.Id}",
					Result = false
				};
			}

			existing.Name = light.Name;
			existing.MeasurementUnitId = light.MeasurementUnitId;
			existing.FromUnit = light.FromUnit;
			existing.ToUnit = light.ToUnit;
			existing.UpdatedAt = DateTime.UtcNow;

			var result = await _unitOfWork.LightRepository.Update(existing);
			return new ApiResult<bool>
			{
				Result = result,
				ApiCode = ApiCode.Success
			};
		}
	}
}

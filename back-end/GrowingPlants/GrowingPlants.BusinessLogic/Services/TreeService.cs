﻿using System;
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
	public class TreeService : ITreeService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger _logger;

		public TreeService(ILoggerFactory loggerFactory, IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_logger = loggerFactory.CreateLogger(typeof(TreeService));
		}

		public async Task<ApiResult<bool>> InsertTrees(List<Tree> trees)
		{
			if (trees == null || !trees.Any())
			{
				_logger.LogError("Trees is empty");
				return new ApiResult<bool>
				{
					ApiCode = ApiCode.EmptyOrNullListObjects,
					ErrorMessage = "Trees inputted is empty",
					Result = false
				};
			}

			_logger.LogInformation($"Trees to insert: {JsonConvert.SerializeObject(trees)}");

			trees.ForEach(x => x.CreatedAt = DateTime.UtcNow);

			var result = await _unitOfWork.TreeRepository.Insert(trees);

			return new ApiResult<bool>
			{
				ApiCode = ApiCode.Success,
				Result = result
			};
		}

		public async Task<ApiResult<bool>> UpdateTree(Tree tree)
		{
			if (tree == null)
			{
				_logger.LogError("Tree is null");
				return new ApiResult<bool>
				{
					ApiCode = ApiCode.NullObject,
					ErrorMessage = "Tree inputted is null",
					Result = false
				};
			}

			_logger.LogInformation($"Tree to update: {JsonConvert.SerializeObject(tree)}");

			var existing = await _unitOfWork.TreeRepository.GetById(tree.Id);
			if (existing == null)
			{
				_logger.LogError($"Tree not found with id: {tree.Id}");
				return new ApiResult<bool>
				{
					ApiCode = ApiCode.NotFound,
					ErrorMessage = $"Tree not found with id: {tree.Id}",
					Result = false
				};
			}

			existing.Name = tree.Name;
			existing.Description = tree.Description;
			existing.ComparisonWith = tree.ComparisonWith;
			existing.ComparisonAgainst = tree.ComparisonAgainst;
			existing.ExposureTime = tree.ExposureTime;
			existing.FloweringTime = tree.FloweringTime;
			existing.GardenType = tree.GardenType;
			existing.GerminationTime = tree.GerminationTime;
			existing.HarvestTime = tree.HarvestTime;
			existing.HumidityId = tree.HumidityId;
			existing.LightId = tree.LightId;
			existing.Picture = tree.Picture;
			existing.PlantingGuide = tree.PlantingGuide;
			existing.VegetativeTime = tree.VegetativeTime;
			existing.TemperatureId = tree.TemperatureId;
			existing.UpdatedAt = DateTime.UtcNow;

			var result = await _unitOfWork.TreeRepository.Update(existing);
			return new ApiResult<bool>
			{
				Result = result,
				ApiCode = ApiCode.Success
			};
		}
	}
}

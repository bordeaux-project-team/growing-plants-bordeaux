using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.BusinessLogic.UnitOfWorks;
using GrowingPlants.Infrastructure.Models;
using GrowingPlants.Infrastructure.Utilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<ApiResult<Tree>> GetTree(int id)
        {
            return new ApiResult<Tree>
            {
                ApiCode = ApiCode.Success,
                Result = await _unitOfWork.TreeRepository.GetFirstOrDefault(x => x.Id == id)
            };
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

            var existing = await _unitOfWork.TreeRepository.GetFirstOrDefault(x => x.Id == tree.Id);
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
            existing.EnvironmentType = tree.EnvironmentType;
            existing.GerminationTime = tree.GerminationTime;
            existing.HarvestTime = tree.HarvestTime;
            existing.Humidity = tree.Humidity;
            existing.Light = tree.Light;
            existing.PlantType = tree.PlantType;
            existing.WaterLevel = tree.WaterLevel;
            existing.PlantingGuide = tree.PlantingGuide;
            existing.VegetativeTime = tree.VegetativeTime;
            existing.Temperature = tree.Temperature;
            existing.UpdatedAt = DateTime.UtcNow;
            existing.PictureId = tree.PictureId;

            tree.Picture.ConvertToByteArray();
            existing.Picture = tree.Picture;

            var result = await _unitOfWork.TreeRepository.Update(existing);
            return new ApiResult<bool>
            {
                Result = result,
                ApiCode = ApiCode.Success
            };
        }

        public async Task<ApiResult<bool>> InsertOrUpdateFavoriteTree(FavoriteTree favoriteTree)
        {
            if (favoriteTree == null)
            {
                _logger.LogError("FavoriteTree is null");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NullObject,
                    ErrorMessage = "FavoriteTree inputted is null",
                    Result = false
                };
            }

            var existing = await _unitOfWork.FavoriteTreeRepository.GetFirstOrDefault(x => x.Id == favoriteTree.Id);
            if (existing == null)
            {
                _logger.LogInformation($"FavoriteTree to insert: {JsonConvert.SerializeObject(favoriteTree)}");
                var insertResult = await _unitOfWork.FavoriteTreeRepository.Insert(favoriteTree);
                return new ApiResult<bool>
                {
                    Result = insertResult,
                    ApiCode = ApiCode.Success
                };
            }

            _logger.LogInformation($"FavoriteTree to update: {JsonConvert.SerializeObject(favoriteTree)}");

            existing.IsFavorite = favoriteTree.IsFavorite;

            var updateResult = await _unitOfWork.FavoriteTreeRepository.Update(existing);
            return new ApiResult<bool>
            {
                Result = updateResult,
                ApiCode = ApiCode.Success
            };
        }

        public async Task<ApiResult<List<Tree>>> GetPlantedTrees(int userId, int limit)
        {
            var plantedTrees = await _unitOfWork.PlantingProcessRepository.GetPlantedListTrees(userId, limit);
            if (plantedTrees == null || !plantedTrees.Any())
            {
                return new ApiResult<List<Tree>>
                {
                    Result = null,
                    ApiCode = ApiCode.NotFound
                };
            }
            _logger.LogInformation($"User {userId} - limit {limit}: {JsonConvert.SerializeObject(plantedTrees)}");

            plantedTrees.ForEach(x => x.Picture.ConvertToBase64());

            return new ApiResult<List<Tree>>
            {
                Result = plantedTrees,
                ApiCode = ApiCode.Success
            };
        }

        public async Task<ApiResult<TreeSearch>> SearchTrees(TreeSearch treeSearch)
        {
            if (treeSearch == null)
            {
                _logger.LogError("TreeSearch is null");
                return new ApiResult<TreeSearch>
                {
                    ApiCode = ApiCode.NullObject,
                    ErrorMessage = "TreeSearch inputted is null",
                    Result = null
                };
            }
            _logger.LogInformation($"Tree search criteria: {JsonConvert.SerializeObject(treeSearch)}");
            var searchedTrees = await _unitOfWork.TreeRepository.SearchTrees(treeSearch);
            if (searchedTrees == null || !searchedTrees.Any())
            {
                return new ApiResult<TreeSearch>
                {
                    Result = null,
                    ApiCode = ApiCode.NotFound,
                };
            }

            searchedTrees.ForEach(x => x.Picture.ConvertToBase64());

            var nextPage = new TreeSearch
            {
                Text = treeSearch.Text,
                PlantType = treeSearch.PlantType,
                WaterLevel = treeSearch.WaterLevel,
                PageNumber = treeSearch.PageNumber + 1,
                Temperature = treeSearch.Temperature
            };
            treeSearch.NextPage = nextPage;
            treeSearch.Trees = searchedTrees;

            return new ApiResult<TreeSearch>
            {
                Result = treeSearch,
                ApiCode = ApiCode.Success
            };
        }

        public async Task<ApiResult<bool>> InsertPlantTypes(List<PlantType> plantTypes)
        {
            if (plantTypes == null || !plantTypes.Any())
            {
                _logger.LogError("PlantTypes is empty");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.EmptyOrNullListObjects,
                    ErrorMessage = "PlantTypes inputted is empty",
                    Result = false
                };
            }

            _logger.LogInformation($"PlantTypes to insert: {JsonConvert.SerializeObject(plantTypes)}");

            plantTypes.ForEach(x => x.CreatedAt = DateTime.UtcNow);

            var result = await _unitOfWork.PlantTypeRepository.Insert(plantTypes);

            return new ApiResult<bool>
            {
                ApiCode = ApiCode.Success,
                Result = result
            };
        }

        public async Task<ApiResult<bool>> UpdatePlantType(PlantType plantType)
        {
            if (plantType == null)
            {
                _logger.LogError("PlantType is null");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NullObject,
                    ErrorMessage = "PlantType inputted is null",
                    Result = false
                };
            }

            _logger.LogInformation($"PlantType to update: {JsonConvert.SerializeObject(plantType)}");

            var existing = await _unitOfWork.PlantTypeRepository.GetFirstOrDefault(x => x.Id == plantType.Id);
            if (existing == null)
            {
                _logger.LogError($"PlantType not found with id: {plantType.Id}");
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.NotFound,
                    ErrorMessage = $"PlantType not found with id: {plantType.Id}",
                    Result = false
                };
            }

            existing.Name = plantType.Name;
            existing.UpdatedAt = DateTime.UtcNow;

            var result = await _unitOfWork.PlantTypeRepository.Update(existing);
            return new ApiResult<bool>
            {
                Result = result,
                ApiCode = ApiCode.Success
            };
        }
    }
}

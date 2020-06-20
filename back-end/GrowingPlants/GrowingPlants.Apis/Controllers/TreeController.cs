using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.Infrastructure.Models;
using GrowingPlants.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GrowingPlants.Apis.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/tree")]
    public class TreeController : ControllerBase
    {
        private readonly ITreeService _treeService;
        private readonly ILogger _logger;

        public TreeController(ILoggerFactory loggerFactory, ITreeService treeService)
        {
            _treeService = treeService;
            _logger = loggerFactory.CreateLogger(typeof(TreeController));
        }

        [HttpGet]
        [Route("user/{userId}/planted-trees/limit/{limit}")]
        public async Task<ApiResult<List<Tree>>> GetPlantedTrees(int userId, int limit)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Get planted trees");

                var result = await _treeService.GetPlantedTrees(userId, limit);

                _logger.LogInformation("Get planted trees complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Get planted trees error: {ex}");

                return new ApiResult<List<Tree>>
                {
                    Result = null,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [HttpPost]
        [Route("search")]
        public async Task<ApiResult<TreeSearch>> SearchTrees(TreeSearch treeSearch)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Search trees");

                var result = await _treeService.SearchTrees(treeSearch);

                _logger.LogInformation("Search trees complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Search trees error: {ex}");

                return new ApiResult<TreeSearch>
                {
                    Result = null,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [Authorize(Roles = Constants.UserRole.Admin)]
        [HttpPost]
        [Route("insert")]
        public async Task<ApiResult<bool>> InsertTrees(IEnumerable<Tree> trees)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Insert trees");

                var result = await _treeService.InsertTrees(trees?.ToList());

                _logger.LogInformation("Insert trees complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Insert trees error: {ex}");

                return new ApiResult<bool>
                {
                    Result = false,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [Authorize(Roles = Constants.UserRole.Admin)]
        [HttpPut]
        [Route("{id}/update")]
        public async Task<ApiResult<bool>> UpdateTree(int id, Tree tree)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Update tree");

                tree.Id = id;

                var result = await _treeService.UpdateTree(tree);

                _logger.LogInformation("Update tree complete");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Update tree error: {ex}");

                return new ApiResult<bool>
                {
                    Result = false,
                    ApiCode = ApiCode.UnknownError,
                    ErrorMessage = ex.ToString()
                };
            }
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<ApiResult<bool>> InsertOrUpdateFavoriteTree(FavoriteTree favoriteTree)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                _logger.LogInformation("Insert or update favorite tree");

                var result = await _treeService.InsertOrUpdateFavoriteTree(favoriteTree);

                _logger.LogInformation("Insert or update favorite tree");

                stopwatch.Stop();
                result.ExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
                _logger.LogInformation($"Execution time: {result.ExecutionTime}ms");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Insert or update favorite tree error: {ex}");

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

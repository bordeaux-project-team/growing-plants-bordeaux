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
    [Authorize(Roles = Constants.UserRole.Admin)]
    [ApiController]
    [Route("api/[controller]")]
    public class TreeController : ControllerBase
    {
        private readonly ITreeService _treeService;
        private readonly ILogger _logger;

        public TreeController(ILoggerFactory loggerFactory, ITreeService treeService)
        {
            _treeService = treeService;
            _logger = loggerFactory.CreateLogger(typeof(TreeController));
        }


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

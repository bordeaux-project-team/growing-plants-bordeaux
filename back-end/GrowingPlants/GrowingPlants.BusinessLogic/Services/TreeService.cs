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
					ApiCode = ApiCode.EmptyTrees,
					Result = false
				};
			}

			_logger.LogInformation($"Trees to insert: {JsonConvert.SerializeObject(trees)}");

			var result = await _unitOfWork.TreeRepository.Insert(trees);

			return new ApiResult<bool>
			{
				ApiCode = ApiCode.Success,
				Result = result
			};
		}
	}
}

using GrowingPlants.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowingPlants.BusinessLogic.IServices
{
    public interface ITreeService
    {
        Task<ApiResult<bool>> InsertTrees(List<Tree> trees);
        Task<ApiResult<bool>> UpdateTree(Tree tree);
        Task<ApiResult<bool>> InsertOrUpdateFavoriteTree(FavoriteTree favoriteTree);
        Task<ApiResult<List<Tree>>> GetPlantedTrees(int userId, int limit);
        Task<ApiResult<TreeSearch>> SearchTrees(TreeSearch treeSearch);
        Task<ApiResult<bool>> InsertPlantTypes(List<PlantType> plantTypes);
        Task<ApiResult<bool>> UpdatePlantType(PlantType plantType);
        Task<ApiResult<Tree>> GetTree(int id);
    }
}

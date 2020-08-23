using GrowingPlants.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowingPlants.DataAccess.IRepositories
{
    public interface IPlantingProcessRepository : IRepository<PlantingProcess>
    {
        Task<List<Tree>> GetPlantedListTrees(int userId, int limit);
        Task<List<PlantingProcess>> GetByUserId(int userId);
    }
}

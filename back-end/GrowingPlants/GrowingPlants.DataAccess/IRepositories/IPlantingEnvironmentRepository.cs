using System.Collections.Generic;
using System.Threading.Tasks;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.IRepositories
{
    public interface IPlantingEnvironmentRepository : IRepository<PlantingEnvironment>
    {
        Task<List<PlantingEnvironment>> GetByUserId(int userId);
    }
}

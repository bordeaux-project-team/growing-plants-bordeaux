using GrowingPlants.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowingPlants.DataAccess.IRepositories
{
    public interface IPlantingSpotRepository : IRepository<PlantingSpot>
    {
        Task<List<PlantingSpot>> GetPlantingSpotsByEnvironmentId(int id);
    }
}

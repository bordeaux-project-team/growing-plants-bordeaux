using System.Collections.Generic;
using System.Threading.Tasks;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.IRepositories
{
    public interface IPlantingSpotRepository : IRepository<PlantingSpot>
    {
        Task<List<PlantingSpot>> GetPlantingSpotsByEnvironmentId(int id);
    }
}

using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.Repositories
{
    public class PlantingEnvironmentRepository : Repository<PlantingEnvironment>, IPlantingEnvironmentRepository
    {
        public PlantingEnvironmentRepository(GrowingPlantsContext context) : base(context)
        {
        }
    }
}

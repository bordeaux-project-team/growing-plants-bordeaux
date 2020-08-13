using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.Repositories
{
    public class PlantingActionRepository : Repository<PlantingAction>, IPlantingActionRepository
    {
        public PlantingActionRepository(GrowingPlantsContext context) : base(context)
        {
        }
    }
}

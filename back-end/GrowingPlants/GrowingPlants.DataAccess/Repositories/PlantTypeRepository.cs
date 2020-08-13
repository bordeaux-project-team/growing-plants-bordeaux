using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.Repositories
{
    public class PlantTypeRepository : Repository<PlantType>, IPlantTypeRepository
    {
        public PlantTypeRepository(GrowingPlantsContext context) : base(context)
        {
        }
    }
}

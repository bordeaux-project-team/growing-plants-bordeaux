using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.Repositories
{
    public class GardenRepository : Repository<Garden>, IGardenRepository
    {
        public GardenRepository(GrowingPlantsContext context) : base(context)
        {
        }
    }
}

using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.Repositories
{
    public class TemperatureRepository : Repository<Temperature>, ITemperatureRepository
    {
        public TemperatureRepository(GrowingPlantsContext context) : base(context)
        {
        }
    }
}

using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.Repositories
{
    public class MeasurementUnitRepository : Repository<MeasurementUnit>, IMeasurementUnitRepository
    {
        public MeasurementUnitRepository(GrowingPlantsContext context) : base(context)
        {
        }
    }
}

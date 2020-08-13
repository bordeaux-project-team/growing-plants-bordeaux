using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.Repositories
{
    public class RecurrenceRepository : Repository<Recurrence>, IRecurrenceRepository
    {
        public RecurrenceRepository(GrowingPlantsContext context) : base(context)
        {
        }
    }
}

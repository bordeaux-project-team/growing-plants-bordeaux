using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.Repositories
{
    public class ProcessStepRepository : Repository<ProcessStep>, IProcessStepRepository
    {
        public ProcessStepRepository(GrowingPlantsContext context) : base(context)
        {
        }
    }
}

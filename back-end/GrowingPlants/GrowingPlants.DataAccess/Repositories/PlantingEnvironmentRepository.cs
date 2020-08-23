using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GrowingPlants.DataAccess.Repositories
{
    public class PlantingEnvironmentRepository : Repository<PlantingEnvironment>, IPlantingEnvironmentRepository
    {
        public PlantingEnvironmentRepository(GrowingPlantsContext context) : base(context)
        {
        }

        public async Task<List<PlantingEnvironment>> GetByUserId(int userId)
        {
            return await Context.PlantingEnvironments
                .Where(x => x.UserId == userId)
                .Include(x => x.PlantingSpots)
                .ToListAsync();
        }
    }
}

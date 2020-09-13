using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowingPlants.DataAccess.Repositories
{
    public class PlantingSpotRepository : Repository<PlantingSpot>, IPlantingSpotRepository
    {
        public PlantingSpotRepository(GrowingPlantsContext context) : base(context)
        {
        }

        public async Task<List<PlantingSpot>> GetPlantingSpotsByEnvironmentId(int id)
        {
            return await Context
                .PlantingSpots
                .Include(x => x.Tree)
                .Where(x => x.PlantingEnvironmentId != null && x.PlantingEnvironmentId.Value == id)
                .ToListAsync();
        }
    }
}

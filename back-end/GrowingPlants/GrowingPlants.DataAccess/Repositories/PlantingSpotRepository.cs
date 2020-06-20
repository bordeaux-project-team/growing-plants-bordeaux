using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

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
                .Where(x => x.PlantingEnvironmentId != null && x.PlantingEnvironmentId.Value == id)
                .ToListAsync();
        }
    }
}

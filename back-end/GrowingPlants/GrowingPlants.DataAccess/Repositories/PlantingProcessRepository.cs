using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowingPlants.DataAccess.Repositories
{
    public class PlantingProcessRepository : Repository<PlantingProcess>, IPlantingProcessRepository
    {
        public PlantingProcessRepository(GrowingPlantsContext context) : base(context)
        {
        }

        public async Task<List<Tree>> GetPlantedListTrees(int userId, int limit)
        {
            return await Context.PlantingProcesses
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.StartDate)
                .Take(limit)
                .Include(x => x.Tree)
                .Select(x => x.Tree)
                .ToListAsync();
        }
    }
}

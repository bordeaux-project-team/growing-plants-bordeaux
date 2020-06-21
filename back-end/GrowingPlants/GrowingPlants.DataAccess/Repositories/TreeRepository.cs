using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowingPlants.DataAccess.Repositories
{
    public class TreeRepository : Repository<Tree>, ITreeRepository
    {
        public TreeRepository(GrowingPlantsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tree>> GetAll()
        {
            return await Context.Trees
                .Include(tree => tree.Temperature)
                .Include(tree => tree.Light)
                .Include(tree => tree.Humidity)
                .ToListAsync();
        }
    }
}

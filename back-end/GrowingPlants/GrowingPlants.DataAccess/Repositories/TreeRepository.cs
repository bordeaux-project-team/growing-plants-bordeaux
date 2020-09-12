using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;
using GrowingPlants.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Tree>> SearchTrees(TreeSearch treeSearch)
        {
            var treeRepo = GetQueryable();
            if (!string.IsNullOrEmpty(treeSearch.Text))
            {
                treeRepo = treeRepo.Where(x => x.Name.Contains(treeSearch.Text));
            }

            if (treeSearch.WaterLevel != null)
            {
                treeRepo = treeRepo.Where(x => x.WaterLevel == treeSearch.WaterLevel);
            }

            if (!string.IsNullOrEmpty(treeSearch.Temperature))
            {
                treeRepo = treeRepo.Where(x => x.Temperature == treeSearch.Temperature);
            }

            if (!string.IsNullOrEmpty(treeSearch.PlantType))
            {
                treeRepo = treeRepo.Where(x => x.PlantType == treeSearch.PlantType);
            }

            return await treeRepo
                .OrderBy(x => x.Name)
                .Skip((treeSearch.PageNumber - 1) * Constants.TreeSearchPagination.RecordsPerPage)
                .Take(Constants.TreeSearchPagination.RecordsPerPage)
                .ToListAsync();
        }
    }
}

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
            var treesByText = Context.Trees.AsQueryable();
            if (!string.IsNullOrEmpty(treeSearch.Text))
            {
                treesByText = treesByText.Where(x => x.Name.Contains(treeSearch.Text));
            }

            var treesByWaterLevel = Context.Trees.AsQueryable();
            if (treeSearch.WaterLevel != null)
            {
                treesByWaterLevel = treesByWaterLevel.Where(x => x.WaterLevel == treeSearch.WaterLevel);
            }

            var treesByTemperatureId = Context.Trees.AsQueryable();
            if (!string.IsNullOrEmpty(treeSearch.Temperature))
            {
                treesByTemperatureId = treesByTemperatureId.Where(x => x.Temperature == treeSearch.Temperature);
            }

            var treesByPlantTypeId = Context.Trees.AsQueryable();
            if (!string.IsNullOrEmpty(treeSearch.PlantType))
            {
                treesByPlantTypeId = treesByPlantTypeId.Where(x => x.PlantType == treeSearch.PlantType);
            }

            return await treesByText
                .Concat(treesByWaterLevel)
                .Concat(treesByTemperatureId)
                .Concat(treesByPlantTypeId)
                .Distinct()
                .OrderBy(x => x.Name)
                .Skip((treeSearch.PageNumber - 1) * Constants.TreeSearchPagination.RecordsPerPage)
                .Take(Constants.TreeSearchPagination.RecordsPerPage)
                .ToListAsync();
        }
    }
}

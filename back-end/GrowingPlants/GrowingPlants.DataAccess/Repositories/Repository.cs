using System.Collections.Generic;
using System.Threading.Tasks;
using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GrowingPlants.DataAccess.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly GrowingPlantsContext Context;

        protected Repository(GrowingPlantsContext context)
        {
            Context = context;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Insert(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            var saveResult = await Context.SaveChangesAsync();
            return saveResult > 0;
        }

        public async Task<bool> Insert(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
            var saveResult = await Context.SaveChangesAsync();
            return saveResult > 0;
        }

        public async Task<bool> Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            var saveResult = await Context.SaveChangesAsync();
            return saveResult > 0;
        }

        public async Task<bool> Update(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);
            var saveResult = await Context.SaveChangesAsync();
            return saveResult > 0;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            var saveResult = await Context.SaveChangesAsync();
            return saveResult > 0;
        }

        public async Task<bool> Delete(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            var saveResult = await Context.SaveChangesAsync();
            return saveResult > 0;
        }
    }
}

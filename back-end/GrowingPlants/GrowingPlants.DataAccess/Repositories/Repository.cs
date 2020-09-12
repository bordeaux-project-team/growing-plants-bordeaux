using System;
using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GrowingPlants.DataAccess.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly GrowingPlantsContext Context;

        protected Repository(GrowingPlantsContext context)
        {
            Context = context;
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public async Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
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

using GrowingPlants.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowingPlants.DataAccess.IRepositories
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        Task<TEntity> GetById(int id);
        Task<bool> Insert(TEntity entity);
        Task<bool> Insert(IEnumerable<TEntity> entities);
        Task<bool> Update(TEntity entity);
        Task<bool> Update(IEnumerable<TEntity> entities);
        Task<bool> Delete(TEntity entity);
        Task<bool> Delete(IEnumerable<TEntity> entities);
    }
}

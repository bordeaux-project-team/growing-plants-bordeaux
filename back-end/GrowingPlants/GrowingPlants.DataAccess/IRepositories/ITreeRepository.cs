using GrowingPlants.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowingPlants.DataAccess.IRepositories
{
    public interface ITreeRepository : IRepository<Tree>
    {
        Task<IEnumerable<Tree>> GetAll();
    }
}

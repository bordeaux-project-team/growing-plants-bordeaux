using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.IRepositories
{
    public interface ITreeRepository : IRepository<Tree>
    {
        Task<IEnumerable<Tree>> GetAll();
    }
}

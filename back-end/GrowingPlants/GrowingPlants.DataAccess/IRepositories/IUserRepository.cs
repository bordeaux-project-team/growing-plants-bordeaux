using System.Threading.Tasks;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindUserByEmail(string email);
    }
}

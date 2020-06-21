using GrowingPlants.Infrastructure.Models;
using System.Threading.Tasks;

namespace GrowingPlants.DataAccess.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindUserByEmail(string email);
    }
}

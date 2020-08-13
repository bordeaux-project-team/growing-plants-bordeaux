using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GrowingPlants.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(GrowingPlantsContext context) : base(context)
        {
        }

        public async Task<User> FindUserByEmail(string email)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}

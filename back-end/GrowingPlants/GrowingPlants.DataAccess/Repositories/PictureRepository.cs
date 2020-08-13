using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.Repositories
{
    public class PictureRepository : Repository<Picture>, IPictureRepository
    {
        public PictureRepository(GrowingPlantsContext context) : base(context)
        {
        }
    }
}

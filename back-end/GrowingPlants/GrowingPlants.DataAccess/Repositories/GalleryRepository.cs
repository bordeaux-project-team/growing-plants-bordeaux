using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.Repositories
{
    public class GalleryRepository : Repository<Gallery>, IGalleryRepository
    {
        public GalleryRepository(GrowingPlantsContext context) : base(context)
        {
        }
    }
}

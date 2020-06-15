using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.Repositories
{
	public class NotificationRepository : Repository<Notification>, INotificationRepository
	{
		public NotificationRepository(GrowingPlantsContext context) : base(context)
		{
		}
	}
}

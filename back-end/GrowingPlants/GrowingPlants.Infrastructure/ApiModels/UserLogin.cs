using GrowingPlants.Infrastructure.DbModels;

namespace GrowingPlants.Infrastructure.ApiModels
{
	public class UserLogin
	{
		public User User { get; set; }
		public string Token { get; set; }
	}
}

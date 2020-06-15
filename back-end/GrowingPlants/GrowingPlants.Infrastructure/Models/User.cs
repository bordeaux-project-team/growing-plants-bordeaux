using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrowingPlants.Infrastructure.Models
{
	public class User : BaseModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public bool Gender { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string Role { get; set; }
		public string Password { get; set; }
		public bool Status { get; set; }

		[NotMapped]
		public string Token { get; set; }

		public List<FavoriteTree> FavoriteTrees { get; set; }
		public List<PlantingProcess> PlantingProcesses { get; set; }
	}
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using GrowingPlants.Infrastructure.Utilities;

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
		public Constants.UserRole Role { get; set; }
		public string Password { get; set; }
		public bool Status { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }

		[NotMapped]
		public string Token { get; set; }
	}
}

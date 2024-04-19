using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon_2024_API.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PictureUrl { get; set; }
		public string WorkId { get; set; }

		public ApplicationUser(string id, string firstName, string lastName, string pictureUrl, string workId)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
			PictureUrl = pictureUrl;
			WorkId = workId;
		}
	}
}

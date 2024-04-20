using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon_2024_API.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		public string? FirstName { get; set; }
		[Required]
		public string? LastName { get; set; }
		[Required]
		public string? PictureUrl { get; set; }
		[Required]
		public string? WorkId { get; set; }
		[Required]
		[StringLength(20)]
		[DefaultValue("pending")]
		//active, pending, inactive
		public string? UserStatus { get; set; }

		public Dictionary<string, object> ToDictionary => new Dictionary<string, object>
		{
			{ nameof(Id), Id ?? ""},
			{ nameof(FirstName), FirstName ?? ""},
			{ nameof(LastName), LastName ?? ""},
			{ nameof(PictureUrl), PictureUrl ?? ""},
			{ nameof(WorkId), WorkId ?? ""},
			{ nameof(PhoneNumber), PhoneNumber ?? ""},
			{ nameof(Email), Email ?? ""},
			{ nameof(UserStatus), UserStatus ?? ""},

			
		};

        }
}

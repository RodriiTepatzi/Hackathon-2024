using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Hackathon_2024_API.Models
{
    public class Package
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ? Id { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        public float Height { get; set; }
        [Required]
        public float Width { get; set; }
        [Required]
        public float Lenghth { get; set; }
        [Required]
        public DateTime? EntranceDate { get; set; }
        [AllowNull]
        public DateTime? SendDateEstimated { get; set; }
        [Required]
        [StringLength(120)]
        public string? ClientAddress { get; set; }
        [Required]
        [StringLength(100)]
        public string? ClientFullName { get; set; }
        [Required]
        [StringLength(15)]
        public string? ClientPhone { get; set;}
        [Required]
        [StringLength(15)]
        public string? PackageStatus{ get; set;}
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public string? IdShiping { get; set; }
        [Required]
        public string? PackagePictureUrl { get; set; }
        [AllowNull]
        public string? PackageDeliveredPictureUrl { get; set;}

        [NotMapped]
        public double distanceToWereHouse = 0;
        

        //FOREIGN KEY
        [ForeignKey("IdShiping")]
        public Shiping? Shiping { get; set; }


        public Dictionary<string, object> Dictionary => new Dictionary<string, object>
        {
            { nameof(Id), Id ?? "" },
            { nameof(Weight), Weight },
            { nameof(Height), Height },
            { nameof(Width), Width },
            { nameof(Lenghth), Lenghth },
            { nameof(EntranceDate), EntranceDate.HasValue ? EntranceDate.Value.ToString() : "" },
            { nameof(SendDateEstimated), SendDateEstimated.HasValue ? SendDateEstimated.Value.ToString() : "" },
            { nameof(ClientAddress), ClientAddress ?? "" },
            { nameof(ClientFullName), ClientFullName ?? "" },
            { nameof(ClientPhone), ClientPhone ?? "" },
            { nameof(PackageStatus), PackageStatus ?? "" },
            { nameof(Latitude), Latitude},
			{ nameof(Longitude), Longitude},
			{ nameof(IdShiping), IdShiping ?? "" },
            { nameof(PackagePictureUrl), PackagePictureUrl ?? "" },
            { nameof(PackageDeliveredPictureUrl), PackageDeliveredPictureUrl ?? "" }
        };

        }
}

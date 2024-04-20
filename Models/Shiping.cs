using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;

namespace Hackathon_2024_API.Models
{
    public class Shiping
    {
        
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }

        //WareHouse, Awaiting, InRoute, Delivered, NotDelivered
        [Required]
        [StringLength(15)]
        public string? Status { get; set; }

        [Required]
        public string? IdCarrier{ get; set; }

        //add fk for IdCArrier
        [ForeignKey("IdCarrier")]
        public ApplicationUser? Carrier { get; set; }

        [NotMapped]
        public List<string>? Packets { get; set; }
        [NotMapped]
        public double LatAct { get; set; }
        [NotMapped]
        public double LongAct { get; set; }

       

        public Dictionary<string, object> Dictionary => new Dictionary<string, object>
        {

            { nameof(Id), Id is not null ? Id : "" },
            { nameof(Status), Status is not null ? Status: ""},
            { nameof(IdCarrier), IdCarrier is not null ? IdCarrier: ""},

        };


        }
}

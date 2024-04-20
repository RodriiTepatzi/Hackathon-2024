﻿using System.ComponentModel.DataAnnotations.Schema;
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

        public string? IdPacket { get; set; }


        //WareHouse, Awaiting, InRoute, Delivered, NotDelivered
        [Required]
        [StringLength(15)]
        public string? Status { get; set; }

        [Required]
        public string? IdCarrier{ get; set; }

        //add fk for IdCArrier
        [ForeignKey("IdCarrier")]
        public ApplicationUser? Carrier { get; set; }

        public Dictionary<string, object> Dictionary => new Dictionary<string, object>
        {

            { nameof(Id), Id is not null ? Id : "" },
            { nameof(IdPacket), IdPacket is not null ? IdPacket: ""},
            { nameof(Status), Status is not null ? Status: ""},
            { nameof(IdCarrier), IdCarrier is not null ? IdCarrier: ""},

        };


        }
}

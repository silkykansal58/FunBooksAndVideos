using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FunBooksAndVideos.Models.Enums;

namespace FunBooksAndVideos.Models.Entity
{
	public class Membership 
	{
        [Key]
        public Guid MembershipId { get; set; }

        [EnumDataType(typeof(ItemTypeEnum), ErrorMessage = "Please enter a valid Membership")]
        public MembershipEnum MembershipType { get; set; }
        public Guid ItemId { get; set; }

        public bool isActive { get; set; } = false;

        [ForeignKey(nameof(Customer))]
        [Required]
        public Guid CustomerId { get; set; } //  Required foreign key property - Customer 
        public Customer Customer { get; set; } // Required reference navigation to principal - Customer
    }
}


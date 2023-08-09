using System;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Models.DTO
{
	public class MembershipDTO
	{
        [Key]
        public Guid MembershipId { get; set; }

        public Guid ItemId { get; set; }

        [EnumDataType(typeof(ItemTypeEnum), ErrorMessage = "Please enter a valid Membership")]
        public MembershipEnum MembershipType { get; set; }

        public bool isActive { get; set; }

        public Guid CustomerId { get; set; } //  Required foreign key property - Customer 
        //public CustomerDTO Customer { get; set; } // Required reference navigation to principal - Customer
    }
}


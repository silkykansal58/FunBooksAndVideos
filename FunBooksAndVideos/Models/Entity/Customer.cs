using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Models.Entity
{
    // Customer Entity
    public class Customer
	{
        [Required]
        [Key]
        public Guid CustomerId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(2)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [MinLength(5)]
        public string Address { get; set; } = string.Empty;

        public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>(); // Reference navigation to dependent
        public ICollection<Membership> Memberships { get; set; } = new List<Membership>(); // Reference navigation to dependent

    }
}


using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Models.DTO
{
	public class CustomerResponseDTO
	{
        [Required]
        [Key]
        public Guid CustomerId { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;

        public ICollection<PurchaseOrderResponseDTO> PurchaseOrders { get; set; } = new List<PurchaseOrderResponseDTO>();
        public ICollection<MembershipDTO> Memberships { get; set; } = new List<MembershipDTO>();

    }
}
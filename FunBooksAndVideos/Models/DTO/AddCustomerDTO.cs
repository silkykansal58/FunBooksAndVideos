using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Models.DTO
{
	public class AddCustomerDTO
	{
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(2)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [MinLength(5)]
        [StringLength(100)]
        public string Address { get; set; } = string.Empty;
    }
}


using System;
using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Models.DTO
{
	public class ItemIdDTO
	{
        [Key]
        [Required]
        public Guid ItemId { get; set; }
    }
}


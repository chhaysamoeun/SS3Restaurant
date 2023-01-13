using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace SS3Restaurant.Models
{
	public class ProductDTO
	{
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public bool IsStock { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public IFormFile Image { get; set; }

        public Category Category { get; set; }
    }
}


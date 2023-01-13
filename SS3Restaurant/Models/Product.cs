using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS3Restaurant.Models
{
	public class Product
	{
		[Key]
		public Guid ProductId { get; set; }
		[Required]
		[MaxLength(100)]
		[Display(Name ="Product Name")]
		public string ProductName { get; set; }
		public double Price { get; set; }
		public int Qty { get; set; }
		public bool IsStock { get; set; }
		[ForeignKey("Category")]
		public Guid CategoryId { get; set; }
		public string Image { get; set; }

		public Category Category { get; set; }
	}
}


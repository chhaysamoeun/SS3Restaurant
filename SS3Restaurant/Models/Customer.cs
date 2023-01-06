using System;
using System.ComponentModel.DataAnnotations;

namespace SS3Restaurant.Models
{
	public class Customer
	{
		[Key]
		public Guid CustomerId { get; set; }
		[Required]
		[MaxLength(50)]
		[Display(Name ="Customer Name")]
		public string CustomerName { get; set; }
		[Phone]
		[MaxLength(20)]
		public string PhoneNumber { get; set; }
		[EmailAddress]
		[MaxLength(50)]
		public string Email { get; set; }
		[MaxLength(100)]
		[DataType(DataType.MultilineText)]
		public string Address { get; set; }
	}
}


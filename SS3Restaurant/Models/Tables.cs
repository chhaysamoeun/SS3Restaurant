using System;
using System.ComponentModel.DataAnnotations;

namespace SS3Restaurant.Models
{
	public class Tables
	{
		[Key]
		public Guid TableId { get; set; }
		[Required]
		[MaxLength(2)]
		public string TableNumber { get; set; }
	}
}


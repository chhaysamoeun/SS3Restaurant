using System;
using Microsoft.EntityFrameworkCore;

namespace SS3Restaurant.Models
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			:base(options)
		{
		}
		public DbSet<Category> Category { get; set; }
		public DbSet<Customer> Customer { get; set; }
		public DbSet<Product> Product { get; set; }
		public DbSet<Tables> Tables { get; set; }
	}
}


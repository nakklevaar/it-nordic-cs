using ConsoleApp4.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Data
{
	class OnlineStoreContext: DbContext
	{
		private string _connectionString;

		public DbSet<Product> Products { get; set; }

		public DbSet<Customer> Customers { get; set; }

		public DbSet<OrderItem> OrderItems { get; set; }

		public DbSet<Order> Orders { get; set; }

		public OnlineStoreContext()
		{
			_connectionString = @"Data Source=localhost\SQLEXPRESS;"
				+ "Initial Catalog = OnlineStoreEF;"
				+ "Integrated Security=true";
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>().HasAlternateKey(c => c.Name).HasName("UQ_Customers_Name");

			modelBuilder.Entity<OrderItem>().HasKey("OrderId", "ProductId").HasName("PK_OrderItems");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}
	}
}

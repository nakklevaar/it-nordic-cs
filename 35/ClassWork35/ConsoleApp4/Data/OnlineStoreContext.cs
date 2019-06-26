using ConsoleApp4.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Data
{
	class OnlineStoreContext: DbContext
	{
		private string _connectionString;

		public static readonly LoggerFactory MyConsoleLoggerFactory = new LoggerFactory(new[] {
			new ConsoleLoggerProvider((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information, true)});

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
			modelBuilder.Entity<Customer>().HasIndex(c => c.Name).IsUnique();

			modelBuilder.Entity<OrderItem>().HasKey("OrderId", "ProductId").HasName("PK_OrderItems");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLoggerFactory(MyConsoleLoggerFactory).EnableSensitiveDataLogging(true).UseSqlServer(_connectionString);
		}
	}
}

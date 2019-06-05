using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			const string connectionStringTemplate =
				"Data Source={0};" +
				"Initial Catalog={1};" +
				"Integrated Security=true";

			string conenctionString = string.Format(connectionStringTemplate, @"localhost\SQLEXPRESS", "OnlineStore");

			var repository = new OnlineStoreRepository(conenctionString);

			int productCount = repository.GetProductCount();
			Console.WriteLine($"Number of products: {productCount}");

			var products = repository.GetProductList();
			foreach(var product in products)
			{
				Console.WriteLine(product);
			}

			var orderCount = repository.GetOrderCount();
			Console.WriteLine($"Number of orders: {orderCount}");

			var orders = repository.GetOrderList();
			foreach(var id in orders)
			{
				Console.WriteLine(id);
			}

			var newId = repository.AddProduct("Cуперчасы", (decimal)12345.67);
			Console.WriteLine($"New product with id = {newId} added.");
		}
	}
}

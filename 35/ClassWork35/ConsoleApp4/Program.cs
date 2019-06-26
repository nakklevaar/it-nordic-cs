using ConsoleApp4.Data;
using ConsoleApp4.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConsoleApp4
{
	class Program
	{
		private static OnlineStoreContext _context = new OnlineStoreContext();

		static void Main(string[] args)
		{
			//InsertCustomer();

			//InsertProduct();

			//SelectCustomers();

			//MoreQueries();

			//QueryForProducts();

			//UpdateCustomers();

			//UpdateProductsDisconnected();

			DeleteCustomers();
		}

		private static void DeleteCustomers()
		{
			//var customer = _context.Customers.First(c=>c.Id==13);

			var customer = new Customer { Id = 14 };
			_context.Customers.Remove(customer);
			_context.SaveChanges();
		}

		private static void UpdateProductsDisconnected()
		{
			var product = new Product
			{
				Id = 1,
				Name = "Test1",
				Price = 10M - 10M * 0.1M
			};

			using(var newContext = new OnlineStoreContext())
			{
				newContext.Products.Update(product);
				newContext.SaveChanges();
			}
		}

		private static void UpdateCustomers()
		{
			var customer = _context.Customers.First();
			customer.Name = "Mr " + customer.Name;
			_context.SaveChanges();
		}

		private static void QueryForProducts()
		{
			var products = _context.Products.Where(c => EF.Functions.Like(c.Name, "phone%256%"));

		//	var products = _context.Products.Where(p => p.Price > 1000).Select(a => { Console.Write(""); return a; }).ToList();
		}

		private static void MoreQueries()
		{
			//var customers = _context.Customers.Where(c => c.Name.StartsWith("al")).ToList();

			var customers = _context.Customers
				.OrderBy(c => c.Id)
				.Last(c => c.Name.Length > 6);
		}

		private static void SelectCustomers()
		{
			using (var context = new OnlineStoreContext())
			{
				//string alex = "alex 9"; 

				//var allCustomers1 = context.Customers.Where(c=>c.Name == "Alex 11").ToList();

				//var allCustomers2 = context.Customers.Where(c => c.Name == alex).ToList();

				var customers = context.Customers.ToList();
				foreach (var customer in customers)
				{
					Console.WriteLine($"Customer '{customer.Name}' has ID = {customer.Id}");
				}
			}
		}

		private static void InsertCustomer()
		{
			var customer = new Customer { Name = "Alex 9" };
			var customerSet = new Customer[]
			{
				new Customer { Name = "Alex 10" },
				new Customer { Name = "Alex 11" }
			};

			using(var context = new OnlineStoreContext())
			{
				//context.Customers.Add(customer);
				context.Add(customer);
				context.AddRange(customerSet);
				context.SaveChanges();
			}
		}

		private static void InsertProduct()
		{
			var product = new Product { Name = "apple", Price = 30 };

			var productSet = new Product[]
			{
				new Product { Name = "tomato", Price = 25 },
				new Product { Name = "orange", Price = 65 }
			};

			using (var context = new OnlineStoreContext())
			{
				context.Add(product);
				context.AddRange(productSet);
				context.SaveChanges();
			}
		}
	}
}

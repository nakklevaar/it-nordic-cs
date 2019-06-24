using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Domain
{
	public class OrderItem
	{
		public int OrderId { get; set; }

		public Product Product { get; set; }

		public int NumberOfItems { get; set; }

	}
}

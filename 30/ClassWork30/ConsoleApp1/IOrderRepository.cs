using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	public interface IOrderRepository
	{
		int GetOrderCount();

		List<string> GetOrderList();

		int AddOrder(int customerId,DateTimeOffset orderDate,float? discount,List<Tuple<int, int>>productIdCountList);
	}
}

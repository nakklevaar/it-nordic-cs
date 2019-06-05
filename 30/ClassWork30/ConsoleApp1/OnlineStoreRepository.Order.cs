using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp1
{
	public partial class OnlineStoreRepository : IOrderRepository
	{

		public int GetOrderCount()
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "SELECT COUNT(*) FROM dbo.[Order]";
				int result = (int)sqlCommand.ExecuteScalar();
				return result;
			}
		}

		public List<string> GetOrderList()
		{
			var result = new List<string>();

			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "SELECT Id, CustomerId, OrderDate, Discount FROM dbo.[Order] ORDER BY Id";

				using (var sqlDataReader = sqlCommand.ExecuteReader())
				{
					if (!sqlDataReader.HasRows)
					{
						return result;
					}

					int idColumnIndex = sqlDataReader.GetOrdinal("Id");
					int customerIdColumnIndex = sqlDataReader.GetOrdinal("CustomerId");
					int orderDateColumnIndex = sqlDataReader.GetOrdinal("OrderDate");
					int discountColumnIndex = sqlDataReader.GetOrdinal("Discount");

					while (sqlDataReader.Read())
					{
						var id = sqlDataReader.GetInt32(idColumnIndex);

						double discount = (sqlDataReader.IsDBNull(discountColumnIndex)
							? 0
							: sqlDataReader.GetDouble(discountColumnIndex));

						result.Add($"OrderId: {id}, Discount: {discount * 100:0.00}%");
					}

					return result;
				}
			}
		}

		public int AddOrder(int customerId, DateTimeOffset orderDate, float? discount, List<Tuple<int, int>> productIdCountList)
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
				sqlCommand.CommandText = "dbo.AddOrder";

				sqlCommand.Parameters.AddWithValue("@customerId", customerId);
				sqlCommand.Parameters.AddWithValue("@orderDate", orderDate);
				sqlCommand.Parameters.AddWithValue("@discount", discount);

				var idParameter = new SqlParameter("@id", System.Data.SqlDbType.Int);
				idParameter.Direction = System.Data.ParameterDirection.Output;
				sqlCommand.Parameters.Add(idParameter);

				sqlCommand.ExecuteNonQuery();

				int orderId = (int)idParameter.Value;

				sqlCommand.CommandText = "dbo.AddorderItem";
				foreach(var prod in productIdCountList)
				{
					sqlCommand.Parameters.Clear();
					sqlCommand.Parameters.AddWithValue("@orderId", orderId);
					sqlCommand.Parameters.AddWithValue("@productId", 0);
					sqlCommand.Parameters.AddWithValue("@numberOfItems", 0);
				}
				return orderId;
			}
		}
	}
}

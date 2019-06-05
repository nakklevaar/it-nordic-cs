using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp1
{
	public partial class OnlineStoreRepository: IProductRepository
	{
		private readonly string _connectionString;

		public OnlineStoreRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		private SqlConnection GetOpenedSqlConnection()
		{
			var sqlConnection = new SqlConnection(_connectionString);
			sqlConnection.Open();
			return sqlConnection;
		}

	}
}

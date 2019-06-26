using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Reminder.Storage.Sql
{
   public partial class SqlStorage
   {
        private readonly string _connectionString;

        public SqlStorage(string connectionString)
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

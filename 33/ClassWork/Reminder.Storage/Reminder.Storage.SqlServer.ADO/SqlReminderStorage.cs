using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Reminder.Storage.Core;

namespace Reminder.Storage.Sql
{
	public class SqlReminderStorage : IReminderStorage
	{
		private readonly string _connectionString;

		public SqlReminderStorage(string connectionString)
		{
			_connectionString = connectionString;
		}

		public Guid Add(ReminderItemRestricted reminder)
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var cmd = sqlConnection.CreateCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "dbo.AddReminderItem";

				cmd.Parameters.AddWithValue("@contactId", reminder.ContactId);
				cmd.Parameters.AddWithValue("@targetDate", reminder.Date);
				cmd.Parameters.AddWithValue("@message", reminder.Message);
				cmd.Parameters.AddWithValue("@statusId", (byte)reminder.Status);

				var outputIdParameter = new SqlParameter("@reminderId", System.Data.SqlDbType.UniqueIdentifier, 1);
				outputIdParameter.Direction = System.Data.ParameterDirection.Output;
				cmd.Parameters.Add(outputIdParameter);

				cmd.ExecuteNonQuery();

				return (Guid)outputIdParameter.Value;
			}
		}

		public ReminderItem Get(Guid id)
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var cmd = sqlConnection.CreateCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetReminderItemById";

				cmd.Parameters.AddWithValue("@reminderId", id);
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(!reader.HasRows || !reader.Read())
                    {
                        return null;
                    }

                    var result = new ReminderItem();

                    result.Id = id;
                    result.ContactId = reader.GetString(reader.GetOrdinal("ContactId"));
                    result.Date = reader.GetDateTimeOffset(reader.GetOrdinal("TargetDate"));
                    result.Message = reader.GetString(reader.GetOrdinal("Message"));
                    result.Status = (ReminderItemStatus)reader.GetByte(reader.GetOrdinal("StatusId"));

                    return result;
                }
			}
		}

        public List<ReminderItem> Get(ReminderItemStatus status)
        {
            var list = new List<ReminderItem>();

            using (var sqlConnection = GetOpenedSqlConnection())
            {
                var reminder = new ReminderItem();

                var sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = $"SELECT * FROM dbo.ReminderItem WHERE [StatusId] = '{(byte)status}'";

                using (var sqlDataReader = sqlCommand.ExecuteReader())
                {

                    if (!sqlDataReader.HasRows)
                    {
                        return list;
                    }


                    while (sqlDataReader.Read())
                    {
                        var guid = sqlDataReader.GetGuid(0);
                        var contactId = sqlDataReader.GetString(1);
                        var date = sqlDataReader.GetDateTimeOffset(2);
                        var message = sqlDataReader.GetString(3);
                        var status1 = sqlDataReader.GetByte(4);

                        list.Add(new ReminderItem
                        {
                            Id = guid,
                            Date = date,
                            ContactId = contactId,
                            Message = message,
                            Status = (ReminderItemStatus)status1
                        });
                    }

                    return list;
                }
            }
        }

        public void UpdateStatus(IEnumerable<Guid> ids, ReminderItemStatus status)
        {
            List<Guid> list = ids.ToList();

            foreach (var id in list)
            {
                UpdateStatus(id, status);
            }
        }

        public void UpdateStatus(Guid id, ReminderItemStatus status)
        {

            using (var sqlConnection = GetOpenedSqlConnection())
            {

                var sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "dbo.UpdateOneStatus";

                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.Parameters.AddWithValue("@StatusId", (byte)status);


                sqlCommand.ExecuteNonQuery();
            }
        }

        public List<ReminderItem> Get(int count = 0, int startPostion = 0)
        {
            throw new NotImplementedException();
        }

        public List<ReminderItem> Get(ReminderItemStatus status, int count, int startPostion)
        {
            throw new NotImplementedException();
        }


        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Count => throw new NotImplementedException();

        private SqlConnection GetOpenedSqlConnection()
		{
			var sqlConnection = new SqlConnection(_connectionString);
			sqlConnection.Open();

			return sqlConnection;
		}
	}
}

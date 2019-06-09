using Reminder.Storage.Core;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Reminder.Storage.Sql
{
    public partial class SqlStorage : IReminderStorage
    {
        public Guid Add(ReminderItemRestricted reminder)
        {
           using(var sqlConnection = GetOpenedSqlConnection())
           {
                var sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "dbo.AddReminder";

                sqlCommand.Parameters.AddWithValue("@date", reminder.Date);
                sqlCommand.Parameters.AddWithValue("@contactId", reminder.ContactId);
                sqlCommand.Parameters.AddWithValue("@message", reminder.Message);
                sqlCommand.Parameters.AddWithValue("@statusId", (int)reminder.Status);

                var idParameter = new SqlParameter("@id", System.Data.SqlDbType.UniqueIdentifier);
                idParameter.Direction = System.Data.ParameterDirection.Output;
                sqlCommand.Parameters.Add(idParameter);

                sqlCommand.ExecuteNonQuery();

                return (Guid)idParameter.Value;
           }
        }


        public ReminderItem Get(Guid id)
        {
            using (var sqlConnection = GetOpenedSqlConnection())
            {
                var reminder = new ReminderItem();

                var sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = $"SELECT * FROM dbo.ReminderItems WHERE Id = '{id}'";

                using (var sqlDataReader = sqlCommand.ExecuteReader())
                {

                    if (sqlDataReader.Read())
                    {
                        var guid = sqlDataReader.GetGuid(0);
                        var date = sqlDataReader.GetDateTimeOffset(1);
                        var contactId = sqlDataReader.GetString(2);
                        var message = sqlDataReader.GetString(3);
                        var status = sqlDataReader.GetByte(4);

                        reminder.Id = guid;
                        reminder.Date = date;
                        reminder.ContactId = contactId;
                        reminder.Message = message;
                        reminder.Status = (ReminderItemStatus)status;
                    }

                    return reminder;
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
                sqlCommand.CommandText = $"SELECT * FROM dbo.ReminderItems WHERE [StatusId] = '{(int)status}'";

                using (var sqlDataReader = sqlCommand.ExecuteReader())
                {

                    if (!sqlDataReader.HasRows)
                    {
                        return list;
                    }


                    while (sqlDataReader.Read())
                    {
                        var guid = sqlDataReader.GetGuid(0);
                        var date = sqlDataReader.GetDateTimeOffset(1);
                        var contactId = sqlDataReader.GetString(2);
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
                sqlCommand.Parameters.AddWithValue("@StatusId", (int)status);


                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}

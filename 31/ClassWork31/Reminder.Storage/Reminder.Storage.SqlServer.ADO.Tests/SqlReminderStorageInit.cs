using Reminder.Storage.SqlServer.ADO.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Reminder.Storage.SqlServer.ADO.Tests
{
   
    public class SqlReminderStorageInit
    {

        private readonly string _connectionString;

        public SqlReminderStorageInit(string connectionString)
        {
            _connectionString = connectionString;
        }

        private void RunSqlScripts(string scripts)
        {
            using (var sqlConnection = GetOpenedSqlConnection())
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                var sqlInstructions = splitSqlInstructions(script);
                foreach (string sqlInstruction in sqlInstructions)
                {
                    if (string.IsNullOrWhiteSpace(sqlInstruction))
                        continue;
                    cmd.CommandText = sqlInstruction;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private string[] splitSqlInstructions(string script)
        {
            return Regex.Split(script, @"\bGO\b");
        }

        public SqlReminderStorageInit()
        {
            RunSqlScripts(Resources.schema);
            RunSqlScripts(Resources.SPs);
        }

        private SqlConnection GetOpenedSqlConnection()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}

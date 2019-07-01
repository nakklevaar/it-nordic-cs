﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Storage.SqlServer.EF.DbInit
{
    public class ConnectionStringFactory
    {
        public const string DbConnectionName = "DefaultConnection";
        public const string SettingFileName = "appsettings.json";

        public static string GetDbConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                    .AddJsonFile(SettingFileName)
                    .Build();

            return config.GetConnectionString(DbConnectionName);
        }
    }
}

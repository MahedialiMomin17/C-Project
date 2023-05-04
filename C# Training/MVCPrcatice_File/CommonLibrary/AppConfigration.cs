﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonLibrary
{
    public static class AppConfiguration
    {
        public static string connectionString = string.Empty;
        public static string databaseName = string.Empty;
        public static string ValidAudience = string.Empty;
        public static string ValidIssuer = string.Empty;
        public static string Secret = string.Empty;
        public static string ProfilePicPath = string.Empty;

        static AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var currentDirectory = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentDirectory, "appsettings.json");
            configurationBuilder.AddJsonFile($"{path}");
            var root = configurationBuilder.Build();
            connectionString = root.GetSection("MongoDB").GetSection("ConnectionString").Value;
            databaseName = root.GetSection("MongoDB").GetSection("Database").Value;
            ValidAudience = root.GetSection("JWT").GetSection("Development").GetSection("ValidAudience").Value;
            ValidIssuer = root.GetSection("JWT").GetSection("Development").GetSection("ValidIssuer").Value;
            Secret = root.GetSection("JWT").GetSection("Development").GetSection("Secret").Value;
            ProfilePicPath = root.GetSection("ProfileFilePath").Value;

        }
    }
}
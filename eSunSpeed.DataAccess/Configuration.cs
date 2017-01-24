using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using eSunSpeedDomain;

namespace eSunSpeed.DataAccess
{
    internal static class Configuration
    {
        const string DEFAULT_CONNECTION_KEY = "defaultConnection";
                        
        public static string DefaultConnection
        {
            get
            {
                return ConfigurationManager.AppSettings[DEFAULT_CONNECTION_KEY];
            }
        }

        public static string DBProvider
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[DefaultConnection].ProviderName;
            }
        }

        public static string ConnectionString
        {
            get
            {
                return string.Format("server={0};user id={1}; password={2}; database={3}", ConfigurationManager.AppSettings["MySqlServer"].ToString(), ConfigurationManager.AppSettings["MySqlUserId"].ToString(), ConfigurationManager.AppSettings["MySqlPassword"].ToString(), SessionVariables.DBName);
                //Need to correct it
                //return ConfigurationManager.ConnectionStrings[DefaultConnection].ConnectionString;
            }
        }   

    }
}

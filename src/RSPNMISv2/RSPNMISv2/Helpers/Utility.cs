using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RSPNMISv2.Helpers
{
    public static class Utility
    {
        public static string REDIS_CONNECTIONS_SERVER;
        public static string REDIS_CONNECTIONS_PASSWORD;
        public static int REDIS_CONNECTIONS_PORT;
        static Utility()
        {
            REDIS_CONNECTIONS_SERVER = ConfigurationManager.AppSettings["Redis_Connections_Hostname"];
            REDIS_CONNECTIONS_PASSWORD = ConfigurationManager.AppSettings["Redis_Connections_Password"];
            REDIS_CONNECTIONS_PORT = Convert.ToInt32(ConfigurationManager.AppSettings["Redis_Connections_Port"]);
        }
    }
}
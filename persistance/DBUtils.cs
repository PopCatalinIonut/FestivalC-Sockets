using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace festival.persistance
{
    public static class DBUtils
    {
        private static IDbConnection instance = null;

        public static IDbConnection getConnection()
        {
            if (instance == null || instance.State == System.Data.ConnectionState.Closed)
            {
                instance = getNewConnection();
                instance.Open();
            }
            return instance;
        }

        private static IDbConnection getNewConnection()
        {
            return ConnectionFactory.getInstance().createConnection();
        }
    }
    
    public abstract class ConnectionFactory
    {
        protected ConnectionFactory()
        {
        }

        private static ConnectionFactory instance;

        public static ConnectionFactory getInstance()
        {
            if (instance == null)
            {

                Assembly assem = Assembly.GetExecutingAssembly();
                Type[] types = assem.GetTypes();
                foreach (var type in types)
                {
                    if (type.IsSubclassOf(typeof(ConnectionFactory)))
                        instance = (ConnectionFactory)Activator.CreateInstance(type);
                }
            }
            return instance;
        }

        public abstract  IDbConnection createConnection();
    }

    public class SqliteConnectionFactory : ConnectionFactory
    {
        public override IDbConnection createConnection()
        {

            string   returnValue   =  null;
            ConnectionStringSettings settings   = ConfigurationManager. ConnectionStrings ["mainDB"] ;
            if (settings!=null)
                returnValue = settings.ConnectionString;


            string[] returns = returnValue.Split('=');
            string dbString = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location).Replace(@"\", "/");
            
            string kstr = dbString.Replace("/FestivalServer", "");
            dbString = returns[0] + "=" + kstr + "/" + returns[1];
            return new SQLiteConnection(dbString);
        }
    }
}
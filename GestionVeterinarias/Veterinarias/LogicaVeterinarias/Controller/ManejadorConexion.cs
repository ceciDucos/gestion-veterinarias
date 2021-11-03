using System;
using System.Data.SqlClient;
using System.Configuration;

namespace LogicaVeterinarias.Controller
{
    public class ManejadorConexion
    {
        private static ManejadorConexion instance;

        private ManejadorConexion()
        {
        }

        public static ManejadorConexion GetInstance()
        {
            if (instance == null)
            {
                instance = new ManejadorConexion();
            }
            return instance;
        }

        public SqlConnection GetConnection()
        {
            String connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}


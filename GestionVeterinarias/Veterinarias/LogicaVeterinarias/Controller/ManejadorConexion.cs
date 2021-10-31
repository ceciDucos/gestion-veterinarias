using System;
using System.Data.SqlClient;

namespace LogicaVeterinarias.Controller
{
    class ManejadorConexion
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

        public static SqlConnection GetConnection()
        {
            String connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            using (SqlConnection connection = new SqlConnection(connectionString));
            return connection;
        }
    }
}


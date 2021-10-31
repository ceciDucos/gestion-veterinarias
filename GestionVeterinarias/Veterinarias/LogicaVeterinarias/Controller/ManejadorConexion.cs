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
            //ver porque no levanta de connecionString de app.config
            SqlConnection connection = new SqlConnection(@"Data Source =.\SQLEXPRESS;Initial Catalog=GestionVeterinarias;Integrated Security=true");
            //String connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PersistenciaVeterinarias.DAOS
{
    public class DAOClientes
    {
        public DAOClientes() { }

        public bool Member(SqlConnection connection, long cedula) 
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Clientes INNER JOIN Personas ON Personas.cedula = Clientes.cedula WHERE Personas.cedula = @Cedula", connection);
            //SqlCommand command = new SqlCommand("SELECT * FROM Clientes WHERE cedula = @Cedula)", connection);

            SqlParameter cedulaParameter = new SqlParameter(){
		        ParameterName = "@Cedula",
		        Value = cedula,
		        SqlDbType = SqlDbType.BigInt
	        };
	        command.Parameters.Add(cedulaParameter);

            SqlDataReader myReader = command.ExecuteReader();
            return myReader.Read() ? true : false;
        }


        /*
        public void Add(SqlConnection connection, )
        {

        }

        /*
        public bool Find(SqlConnection connection) 
        {
            
        }

        public bool Remove(SqlConnection connection) 
        {
            
        }
        */
    }
}

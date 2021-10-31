using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaVeterinarias.DAOS
{
    public class DAOClientes
    {
        public DAOClientes() { }

        public bool Member(SqlConnection connection, long cedula) 
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Clientes INNER JOIN Personas ON Personas.cedula = Clientes.cedula WHERE Cedula = @Cedula)", connection);
		    SqlParameter cedulaParameter = new SqlParameter(){
		        ParameterName = "@Cedula",
		        Value = cedula,
		        SqlDbType = SqlDbType.BigInt
	        };
	        command.Parameters.Add(cedulaParameter);

            SqlDataReader myReader = myCommand.ExecuteReader();
            return myReader.Read() ? true : false;
        }

        /*
        public bool Find(SqlConnection connection) 
        {
            
        }

        public bool Add(SqlConnection connection) 
        {
            
        }

        public bool Remove(SqlConnection connection) 
        {
            
        }
        */
    }
}

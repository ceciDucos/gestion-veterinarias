using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ModelosVeterinarias.Classes;

namespace PersistenciaVeterinarias.DAOS
{
    public class DAOClientes
    {
        public DAOClientes() { }

        public bool Member(SqlConnection connection, long cedula) 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Clientes INNER JOIN Personas ");
            sb.Append("ON Personas.cedula = Clientes.cedula WHERE Personas.cedula = @Cedula");
            SqlCommand command = new SqlCommand(sb.ToString(), connection);
            SqlParameter cedulaParameter = new SqlParameter(){
		        ParameterName = "@Cedula",
		        Value = cedula,
		        SqlDbType = SqlDbType.BigInt
	        };
	        command.Parameters.Add(cedulaParameter);

            SqlDataReader myReader = command.ExecuteReader();
            bool res = myReader.Read() ? true : false;
            myReader.Close();
            return  res;
        }
        
        public void Add(SqlConnection connection, Cliente cliente)
        {
            //Inserto Persona
            StringBuilder sbPersona = new StringBuilder();
            sbPersona.Append("INSERT INTO Personas(nombre, cedula, telefono)");
            sbPersona.Append($"VALUES('{cliente.Nombre}', {cliente.Cedula}, '{cliente.Telefono}');");

            //Inserto Cliente
            StringBuilder sbCliente = new StringBuilder();
            sbCliente.Append("INSERT INTO Clientes(direccion, mail, password, activo, cedula)");
            sbCliente.Append($"VALUES('{cliente.Direccion}', '{cliente.Correo}', '{cliente.Clave}', {Convert.ToByte(cliente.Activo)}, {cliente.Cedula});");
            
            SqlCommand commandPersona = new SqlCommand(sbPersona.ToString(), connection);
            SqlCommand commandCliente = new SqlCommand(sbCliente.ToString(), connection);
            commandPersona.ExecuteNonQuery();
            commandCliente.ExecuteNonQuery();
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

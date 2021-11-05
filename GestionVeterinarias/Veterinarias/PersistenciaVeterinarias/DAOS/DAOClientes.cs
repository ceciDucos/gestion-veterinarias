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
            sb.Append("SELECT * FROM Cliente INNER JOIN Persona ");
            sb.Append("ON Persona.cedula = Cliente.cedula WHERE Persona.cedula = @Cedula");
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
            sbPersona.Append("INSERT INTO Persona(nombre, cedula, telefono)");
            sbPersona.Append($"VALUES('{cliente.Nombre}', {cliente.Cedula}, '{cliente.Telefono}');");

            //Inserto Cliente
            StringBuilder sbCliente = new StringBuilder();
            sbCliente.Append("INSERT INTO Cliente(cedula, direccion, correo, pass, activo)");
            sbCliente.Append($"VALUES({cliente.Cedula}, '{cliente.Direccion}', '{cliente.Correo}', '{cliente.Pass}', {Convert.ToByte(cliente.Activo)});");

            SqlCommand commandPersona = new SqlCommand(sbPersona.ToString(), connection);
            SqlCommand commandCliente = new SqlCommand(sbCliente.ToString(), connection);
            commandPersona.ExecuteNonQuery();
            commandCliente.ExecuteNonQuery();
        }


        /*
        public bool Find(SqlConnection connection) 
        {
            
        }

        */

        public void Edit(SqlConnection connection, Cliente cliente)
        {
            SqlCommand commandPersona = new SqlCommand
                ("UPDATE Persona SET nombre = @Nombre, telefono = @Telefono WHERE cedula = @Cedula", connection);

            SqlParameter CedulaParameter = new SqlParameter()
            {
                ParameterName = "@Cedula",
                Value = cliente.Cedula,
                SqlDbType = SqlDbType.BigInt
            };

            SqlParameter NombreParameter = new SqlParameter()
            {
                ParameterName = "@Nombre",
                Value = cliente.Nombre,
                SqlDbType = SqlDbType.VarChar
            };

            SqlParameter TelefonoParameter = new SqlParameter()
            {
                ParameterName = "@Telefono",
                Value = cliente.Telefono,
                SqlDbType = SqlDbType.VarChar
            };

            commandPersona.Parameters.Add(CedulaParameter);
            commandPersona.Parameters.Add(NombreParameter);
            commandPersona.Parameters.Add(TelefonoParameter);
            commandPersona.ExecuteNonQuery();

            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Cliente SET direccion=@Direccion, correo=@Correo, ");
            sb.Append("pass=@Pass, activo=@Activo WHERE cedula = @Cedula");

            SqlCommand commandCliente = new SqlCommand(sb.ToString(), connection);

            SqlParameter CedulaParameterDos = new SqlParameter()
            {
                ParameterName = "@Cedula",
                Value = cliente.Cedula,
                SqlDbType = SqlDbType.BigInt
            };

            SqlParameter DireccionParameter = new SqlParameter()
            {
                ParameterName = "@Direccion",
                Value = cliente.Direccion,
                SqlDbType = SqlDbType.VarChar
            };

            SqlParameter CorreoParameter = new SqlParameter()
            {
                ParameterName = "@Correo",
                Value = cliente.Correo,
                SqlDbType = SqlDbType.VarChar
            };

            SqlParameter PassParameter = new SqlParameter()
            {
                ParameterName = "@Pass",
                Value = cliente.Pass,
                SqlDbType = SqlDbType.VarChar
            };

            SqlParameter ActivoParameter = new SqlParameter()
            {
                ParameterName = "@Activo",
                Value = cliente.Activo,
                SqlDbType = SqlDbType.Bit
            };

            commandCliente.Parameters.Add(CedulaParameterDos);
            commandCliente.Parameters.Add(DireccionParameter);
            commandCliente.Parameters.Add(CorreoParameter);
            commandCliente.Parameters.Add(PassParameter);
            commandCliente.Parameters.Add(ActivoParameter);
            commandCliente.ExecuteNonQuery();
        }

        public void Remove(SqlConnection connection, long cedula) 
        {
            //Elimino Cliente
            SqlCommand commandCliente = new SqlCommand($"DELETE FROM Cliente WHERE Cedula = {cedula}", connection);
            //Elimino Persona
            SqlCommand commandPersona = new SqlCommand($"DELETE FROM Persona WHERE Cedula = {cedula}", connection);

            commandCliente.ExecuteNonQuery();
            commandPersona.ExecuteNonQuery();
        }
    }
}

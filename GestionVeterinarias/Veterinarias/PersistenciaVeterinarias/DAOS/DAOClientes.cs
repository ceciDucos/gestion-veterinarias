using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ModelosVeterinarias.Classes;
using ModelosVeterinarias.ValueObject;

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
            sbPersona.Append("INSERT INTO Persona(nombre, cedula, telefono, idVeterinaria)");
            sbPersona.Append($"VALUES(@Nombre, @Cedula, @Telefono, @IdVeterinaria);");

            //Inserto Cliente
            StringBuilder sbCliente = new StringBuilder();
            sbCliente.Append("INSERT INTO Cliente(cedula, direccion, correo, pass, activo)");
            sbCliente.Append($"VALUES( @Cedula, @Direccion, @Correo, @Pass, @Activo);");

            SqlParameter nombreParameter = new SqlParameter()
            {
                ParameterName = "@Nombre",
                Value = cliente.Nombre,
                SqlDbType = SqlDbType.VarChar
            };
            SqlParameter cedulaParameter = new SqlParameter()
            {
                ParameterName = "@Cedula",
                Value = cliente.Cedula,
                SqlDbType = SqlDbType.BigInt
            };
            SqlParameter telefonoParameter = new SqlParameter()
            {
                ParameterName = "@Telefono",
                Value = cliente.Telefono,
                SqlDbType = SqlDbType.VarChar
            };
            SqlParameter idVeterinariaParameter = new SqlParameter()
            {
                ParameterName = "@IdVeterinaria",
                Value = cliente.IdVeterinaria,
                SqlDbType = SqlDbType.Int
            };
            SqlParameter cedula2Parameter = new SqlParameter()
            {
                ParameterName = "@Cedula",
                Value = cliente.Cedula,
                SqlDbType = SqlDbType.BigInt
            };
            SqlParameter direccionParameter = new SqlParameter()
            {
                ParameterName = "@Direccion",
                Value = cliente.Direccion,
                SqlDbType = SqlDbType.VarChar
            };
            SqlParameter correoParameter = new SqlParameter()
            {
                ParameterName = "@Correo",
                Value = cliente.Correo,
                SqlDbType = SqlDbType.VarChar
            };
            SqlParameter passParameter = new SqlParameter()
            {
                ParameterName = "@Pass",
                Value = cliente.Pass,
                SqlDbType = SqlDbType.VarChar
            };
            SqlParameter activoParameter = new SqlParameter()
            {
                ParameterName = "@Activo",
                Value = cliente.Activo,
                SqlDbType = SqlDbType.Bit
            };

            SqlCommand commandPersona = new SqlCommand(sbPersona.ToString(), connection);
            commandPersona.Parameters.Add(cedulaParameter);
            commandPersona.Parameters.Add(nombreParameter);
            commandPersona.Parameters.Add(telefonoParameter);
            commandPersona.Parameters.Add(idVeterinariaParameter);

            SqlCommand commandCliente = new SqlCommand(sbCliente.ToString(), connection);
            commandCliente.Parameters.Add(cedula2Parameter);
            commandCliente.Parameters.Add(direccionParameter);
            commandCliente.Parameters.Add(correoParameter);
            commandCliente.Parameters.Add(passParameter);
            commandCliente.Parameters.Add(activoParameter);

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
            sb.Append("UPDATE Cliente SET direccion=@Direccion, correo=@Correo, pass=@Pass");
            sb.Append("activo=@Activo WHERE cedula = @Cedula");

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


        public List<VOCliente> List(SqlConnection connection, int idToFind)
        {


            List<VOCliente> listClientes = new List<VOCliente>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select p.cedula, p.nombre, p.telefono, p.idVeterinaria, c.direccion, c.correo, c.pass, c.activo ");
            sb.Append(" from Persona p, Cliente c");
            sb.Append(" where p.cedula = c.cedula and p.idVeterinaria = @IdVeterinaria");

            SqlCommand selectCommand = new SqlCommand(sb.ToString(), connection);

            SqlParameter IdVeterinariaParameter = new SqlParameter()
            {
                ParameterName = "@IdVeterinaria",
                Value = idToFind,
                SqlDbType = SqlDbType.Int
            };
            selectCommand.Parameters.Add(IdVeterinariaParameter);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = selectCommand;

            // creo y cargo el dataset
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Cliente");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                long cedula = Convert.ToInt32(dr["cedula"]);
                string nombre = Convert.ToString(dr["nombre"]);
                string telefono = Convert.ToString(dr["telefono"]); 
                int idVeterinaria = Convert.ToInt32(dr["idVeterinaria"]);
                string direccion = Convert.ToString(dr["direccion"]);
                string correo = Convert.ToString(dr["correo"]);
                string pass = Convert.ToString(dr["pass"]);
                bool activo = Convert.ToBoolean(dr["activo"]);
                DAOMascotas daoMascotas = new DAOMascotas();
                List<VOMascota> mascotas = daoMascotas.List(connection, cedula);

                VOCliente vocliente = new VOCliente(cedula, nombre, telefono, idVeterinaria, direccion, correo, pass, activo, mascotas);

                listClientes.Add(vocliente);
            }

            return listClientes;
        }

        public VOCliente Get(SqlConnection connection, long InCedula)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select p.cedula, p.nombre, p.telefono, p.idVeterinaria, c.direccion, c.correo, c.pass, c.activo ");
            sb.Append(" from Persona p, Cliente c");
            sb.AppendFormat(" where p.cedula = @InCedula and p.cedula = c.cedula");

            SqlCommand selectCommand = new SqlCommand(sb.ToString(), connection);

            SqlParameter InCedulaParameter = new SqlParameter()
            {
                ParameterName = "@InCedula",
                Value = InCedula,
                SqlDbType = SqlDbType.BigInt
            };
            selectCommand.Parameters.Add(InCedulaParameter);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = selectCommand;

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Cliente");
            VOCliente vocliente = null;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                long cedula = Convert.ToInt32(dr["cedula"]);
                string nombre = Convert.ToString(dr["nombre"]);
                string telefono = Convert.ToString(dr["telefono"]); 
                int idVeterinaria = Convert.ToInt32(dr["idVeterinaria"]);
                string direccion = Convert.ToString(dr["direccion"]);
                string correo = Convert.ToString(dr["correo"]);
                string pass = Convert.ToString(dr["pass"]);
                bool activo = Convert.ToBoolean(dr["activo"]);
                DAOMascotas daoMascotas = new DAOMascotas();
                List<VOMascota> mascotas = daoMascotas.List(connection, InCedula);
                vocliente = new VOCliente(cedula, nombre, telefono, idVeterinaria, direccion, correo, pass, activo, mascotas);
            }

            return vocliente;
        }
    }
}

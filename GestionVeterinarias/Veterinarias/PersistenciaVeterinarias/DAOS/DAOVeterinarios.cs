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
    public class DAOVeterinarios
    {
        public DAOVeterinarios() { }

        public bool Member(SqlConnection connection, long cedula) 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Veterinario INNER JOIN Persona ");
            sb.Append("ON Persona.cedula = Veterinario.cedula WHERE Persona.cedula = @Cedula");
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
        
        public void Add(SqlConnection connection, Veterinario veterinario)
        {
            //Inserto Veterinario
            StringBuilder sbPersona = new StringBuilder();
            sbPersona.Append("INSERT INTO Persona(nombre, cedula, telefono, idVeterinaria)");
            sbPersona.Append($"VALUES( @Nombre, @Cedula, @Telefono, @IdVeterinaria);");

            //Inserto Veterinario
            StringBuilder sbCliente = new StringBuilder();
            sbCliente.Append("INSERT INTO Veterinario(cedula, horario)");
            sbCliente.Append($"VALUES( @Cedula, @Horario );");

            SqlParameter nombreParameter = new SqlParameter()
            {
                ParameterName = "@Nombre",
                Value = veterinario.Nombre,
                SqlDbType = SqlDbType.VarChar
            };
            SqlParameter cedulaParameter = new SqlParameter()
            {
                ParameterName = "@Cedula",
                Value = veterinario.Cedula,
                SqlDbType = SqlDbType.BigInt
            };
            SqlParameter telefonoParameter = new SqlParameter()
            {
                ParameterName = "@Telefono",
                Value = veterinario.Telefono,
                SqlDbType = SqlDbType.VarChar
            };
            SqlParameter idVeterinariaParameter = new SqlParameter()
            {
                ParameterName = "@IdVeterinaria",
                Value = veterinario.IdVeterinaria,
                SqlDbType = SqlDbType.Int
            };
            SqlParameter cedula2Parameter = new SqlParameter()
            {
                ParameterName = "@Cedula",
                Value = veterinario.Cedula,
                SqlDbType = SqlDbType.BigInt
            };
            SqlParameter horarioParameter = new SqlParameter()
            {
                ParameterName = "@Horario",
                Value = veterinario.Horario,
                SqlDbType = SqlDbType.VarChar
            };

            SqlCommand commandPersona = new SqlCommand(sbPersona.ToString(), connection);
            commandPersona.Parameters.Add(cedulaParameter);
            commandPersona.Parameters.Add(nombreParameter);
            commandPersona.Parameters.Add(telefonoParameter);
            commandPersona.Parameters.Add(idVeterinariaParameter);

            SqlCommand commandVeterinario = new SqlCommand(sbCliente.ToString(), connection);
            commandVeterinario.Parameters.Add(cedula2Parameter);
            commandVeterinario.Parameters.Add(horarioParameter);

            commandPersona.ExecuteNonQuery();
            commandVeterinario.ExecuteNonQuery();
        }


      
        public void Remove(SqlConnection connection, long cedula) 
        {
            //Elimino Veterinario
            SqlCommand commandVeterinario = new SqlCommand($"DELETE FROM Veterinario WHERE cedula = {cedula}", connection);
            //Elimino Persona
            SqlCommand commandPersona = new SqlCommand($"DELETE FROM Persona WHERE cedula = {cedula}", connection);

            commandVeterinario.ExecuteNonQuery();
            commandPersona.ExecuteNonQuery();
        }

        public void Edit(SqlConnection connection, Veterinario veterinario)
        {
            //LOGICA PERSONA
            SqlCommand commandPersona = new SqlCommand
                ("UPDATE Persona SET nombre = @Nombre, telefono = @Telefono WHERE cedula = @Cedula", connection);

            SqlParameter CedulaParameter = new SqlParameter()
            {
                ParameterName = "@Cedula",
                Value = veterinario.Cedula,
                SqlDbType = SqlDbType.BigInt
            };

            SqlParameter NombreParameter = new SqlParameter()
            {
                ParameterName = "@Nombre",
                Value = veterinario.Nombre,
                SqlDbType = SqlDbType.VarChar
            };

            SqlParameter TelefonoParameter = new SqlParameter()
            {
                ParameterName = "@Telefono",
                Value = veterinario.Telefono,
                SqlDbType = SqlDbType.VarChar
            };

             commandPersona.Parameters.Add(CedulaParameter);
             commandPersona.Parameters.Add(NombreParameter);
             commandPersona.Parameters.Add(TelefonoParameter);
             commandPersona.ExecuteNonQuery();

             // FIN PERSONA

             // LOGICA PARA VETERINARIO
             SqlCommand commandVeterinario = new SqlCommand
                ("UPDATE Veterinario SET horario=@Horario WHERE cedula = @Cedula", connection);

            SqlParameter CedulaParameterDos = new SqlParameter()
            {
                ParameterName = "@Cedula",
                Value = veterinario.Cedula,
                SqlDbType = SqlDbType.BigInt
            };


            SqlParameter HorarioParameter = new SqlParameter()
            {
                ParameterName = "@Horario",
                Value = veterinario.Horario,
                SqlDbType = SqlDbType.VarChar
            };

            commandVeterinario.Parameters.Add(CedulaParameterDos);
            commandVeterinario.Parameters.Add(HorarioParameter);
            commandVeterinario.ExecuteNonQuery();
            
            // FIN VETERINARIO 

            
            connection.Close();
        }

        public List<VOVeterinario> List(SqlConnection connection, int idToFind) {


            List<VOVeterinario> listVeterinarios = new List<VOVeterinario>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select p.cedula, p.nombre, p.telefono, p.idVeterinaria, v.horario");
            sb.Append(" from Persona p, Veterinario v");
            sb.Append(" where p.cedula = v.cedula and p.idVeterinaria = @IdVeterinaria");

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
            adapter.Fill(ds, "Veterinario");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                
                long cedula = Convert.ToInt32(dr["cedula"]);
                string nombre = Convert.ToString(dr["nombre"]);
                string telefono = Convert.ToString(dr["telefono"]); 
                int idVeterinaria = Convert.ToInt32(dr["idVeterinaria"]);
                string horario = Convert.ToString(dr["horario"]);
                
                VOVeterinario voveterinario = new VOVeterinario(cedula, nombre, telefono, idVeterinaria, horario);

                listVeterinarios.Add(voveterinario);
            }

            return listVeterinarios;
        }

        public VOVeterinario Get(SqlConnection connection, long InCedula)
        {


            StringBuilder sb = new StringBuilder();
            sb.Append("select p.cedula, p.nombre, p.telefono, p.idVeterinaria, v.horario");
            sb.Append(" from Persona p, Veterinario v");
            sb.AppendFormat(" where p.cedula = {0}", InCedula.ToString());

            SqlCommand selectCommand = new SqlCommand(sb.ToString(), connection);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = selectCommand;

            // creo y cargo el dataset
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Veterinario");
            VOVeterinario voveterinario = null;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                long cedula = Convert.ToInt32(dr["cedula"]);
                string nombre = Convert.ToString(dr["nombre"]);
                string telefono = Convert.ToString(dr["telefono"]); 
                int idVeterinaria = Convert.ToInt32(dr["idVeterinaria"]);
                string horario = Convert.ToString(dr["horario"]);

                voveterinario = new VOVeterinario(cedula, nombre, telefono, idVeterinaria, horario);
            }

            return voveterinario;

        }
    }
    
}

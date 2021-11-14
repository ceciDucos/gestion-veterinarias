using ModelosVeterinarias.Classes;
using ModelosVeterinarias.ValueObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaVeterinarias.DAOS
{
    public class DAOVeterinarias
    {

        public DAOVeterinarias() { }

        public void Add(SqlConnection connection, Veterinaria veterinaria)
        {
            SqlCommand command = new SqlCommand("INSERT INTO veterinaria (nombre, direccion, telefono) VALUES (@Nombre, @Direccion, @Telefono)", connection);

            SqlParameter nombreParameter = new SqlParameter()
            {
                ParameterName = "@Nombre",
                Value = veterinaria.Nombre,
                SqlDbType = SqlDbType.VarChar
            };

            SqlParameter direccionParameter = new SqlParameter()
            {
                ParameterName = "@Direccion",
                Value = veterinaria.Direccion,
                SqlDbType = SqlDbType.VarChar
            };

            SqlParameter telefonoParameter = new SqlParameter()
            {
                ParameterName = "@Telefono",
                Value = veterinaria.Telefono,
                SqlDbType = SqlDbType.VarChar
            };

            command.Parameters.Add(nombreParameter);
            command.Parameters.Add(direccionParameter);
            command.Parameters.Add(telefonoParameter);

            command.ExecuteNonQuery();
        }

        public void Edit(SqlConnection connection, Veterinaria veterinaria)
        {
            SqlCommand command = new SqlCommand("UPDATE veterinaria SET nombre = @Nombre, direccion = @Direccion, telefono = @Telefono WHERE id = @Id", connection);

            SqlParameter idParameter = new SqlParameter()
            {
                ParameterName = "@Id",
                Value = veterinaria.Id,
                SqlDbType = SqlDbType.VarChar
            };

            SqlParameter nombreParameter = new SqlParameter()
            {
                ParameterName = "@Nombre",
                Value = veterinaria.Nombre,
                SqlDbType = SqlDbType.VarChar
            };

            SqlParameter direccionParameter = new SqlParameter()
            {
                ParameterName = "@Direccion",
                Value = veterinaria.Direccion,
                SqlDbType = SqlDbType.VarChar
            };

            SqlParameter telefonoParameter = new SqlParameter()
            {
                ParameterName = "@Telefono",
                Value = veterinaria.Telefono,
                SqlDbType = SqlDbType.VarChar
            };

            command.Parameters.Add(idParameter);
            command.Parameters.Add(nombreParameter);
            command.Parameters.Add(direccionParameter);
            command.Parameters.Add(telefonoParameter);

            command.ExecuteNonQuery();
        }

        public void Delete(SqlConnection connection, int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM veterinaria WHERE id = @Id", connection);

            SqlParameter idParameter = new SqlParameter()
            {
                ParameterName = "@Id",
                Value = id,
                SqlDbType = SqlDbType.VarChar
            };

            command.Parameters.Add(idParameter);

            command.ExecuteNonQuery();
        }

        public List<VOVeterinaria> List(SqlConnection connection)
        {
            List<VOVeterinaria> listVeterinarias = new List<VOVeterinaria>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select p.id, p.nombre, p.direccion, P.telefono");
            sb.Append(" from Veterinaria p;");

            SqlCommand selectCommand = new SqlCommand(sb.ToString(), connection);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = selectCommand;

            // creo y cargo el dataset
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Veterinaria");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                int id = Convert.ToInt32(dr["id"]);
                string nombre = Convert.ToString(dr["nombre"]);
                string direccion = Convert.ToString(dr["direccion"]);
                string telefono = Convert.ToString(dr["telefono"]);

                VOVeterinaria voveterinaria = new VOVeterinaria(id, nombre, direccion, telefono);

                listVeterinarias.Add(voveterinaria);
            }

            return listVeterinarias;
        }
    }
}

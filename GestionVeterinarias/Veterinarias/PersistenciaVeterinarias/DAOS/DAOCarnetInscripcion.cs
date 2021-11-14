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
    public class DAOCarnetInscripcion
    {
        public DAOCarnetInscripcion() { }

        public void Add(SqlConnection connection, byte[] foto, int idMascota)
        {
            SqlCommand command = new SqlCommand("INSERT INTO CarnetInscripcion (expedido, foto, idMascota) VALUES (CAST( GETDATE() AS Date ), @Foto, @IdMascota)", connection);

            SqlParameter fotoParameter = new SqlParameter()
            {
                ParameterName = "@Foto",
                Value = foto,
                SqlDbType = SqlDbType.Image
            };

            SqlParameter idMascotaParameter = new SqlParameter()
            {
                ParameterName = "@IdMascota",
                Value = idMascota,
                SqlDbType = SqlDbType.Int
            };

            command.Parameters.Add(fotoParameter);
            command.Parameters.Add(idMascotaParameter);

            command.ExecuteNonQuery();
        }

        public void Edit(SqlConnection connection, CarnetInscripcion carnet)
        {
            SqlCommand command = new SqlCommand("UPDATE CarnetInscripcion SET expedido = @Expedido, foto = @Foto WHERE numero = @Numero", connection);

            SqlParameter idParameter = new SqlParameter()
            {
                ParameterName = "@Numero",
                Value = carnet.Numero,
                SqlDbType = SqlDbType.VarChar
            };

            SqlParameter expedidoParameter = new SqlParameter()
            {
                ParameterName = "@Expedido",
                Value = carnet.Expedido,
                SqlDbType = SqlDbType.Date
            };

            SqlParameter fotoParameter = new SqlParameter()
            {
                ParameterName = "@Foto",
                Value = carnet.Foto,
                SqlDbType = SqlDbType.Image
            };

            command.Parameters.Add(idParameter);
            command.Parameters.Add(expedidoParameter);
            command.Parameters.Add(fotoParameter);

            command.ExecuteNonQuery();
        }

        public void Delete(SqlConnection connection, int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM carnetInscripcion WHERE idMascota = @Id", connection);
            SqlParameter numParameter = new SqlParameter()
            {
                ParameterName = "@Id",
                Value = id,
                SqlDbType = SqlDbType.Int
            };
            command.Parameters.Add(numParameter);

            command.ExecuteNonQuery();
        }

        public VOCarnetInscripcion Get(SqlConnection connection, int idToFind)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select c.numero, c.expedido, c.foto");
            sb.Append(" from carnetInscripcion c");
            sb.Append(" where c.idMascota = @IdMascota");

            SqlCommand selectCommand = new SqlCommand(sb.ToString(), connection);

            SqlParameter idMascotaParameter = new SqlParameter()
            {
                ParameterName = "@IdMascota",
                Value = idToFind,
                SqlDbType = SqlDbType.Int
            };

            selectCommand.Parameters.Add(idMascotaParameter);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = selectCommand;

            DataSet ds = new DataSet();
            adapter.Fill(ds, "carnetInscripcion");
            VOCarnetInscripcion vocarnet = null;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int numero = Convert.ToInt32(dr["numero"]);
                DateTime expedido = Convert.ToDateTime(dr["expedido"]);
                byte[] foto = (byte[])dr["foto"];
                vocarnet = new VOCarnetInscripcion(numero, expedido, foto);
            }

            return vocarnet;

        }
    }
}

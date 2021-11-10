using ModelosVeterinarias.Classes;
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

            //connection.Open();
            command.ExecuteNonQuery();
            //connection.Close();
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

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
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

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}

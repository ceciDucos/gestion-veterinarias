using System.Data;
using System.Data.SqlClient;
using ModelosVeterinarias.Classes;
using System;

namespace PersistenciaVeterinarias.DAOS
{
    public class DAOMascotas
    {
        public DAOMascotas() { }

        #region Agregar una Mascota
        public void Add(SqlConnection connection, Mascota mascota)
        {
            SqlCommand command = new SqlCommand("INSERT INTO mascota (tipo, nombre, raza, edad, vacunas, cedulaCliente) VALUES (@Tipo, @Nombre, @Raza, @Edad, @Vacunas, @CedulaCliente); SELECT CAST(scope_identity() AS int)", connection);
            SqlParameter tipoParameter = new SqlParameter()
            {
                ParameterName = "@Tipo",
                Value = mascota.TipoAnimal,
                SqlDbType = SqlDbType.Int
            };
            SqlParameter nombreParameter = new SqlParameter()
            {
                ParameterName = "@Nombre",
                Value = mascota.Nombre,
                SqlDbType = SqlDbType.VarChar
            };
            SqlParameter razaParameter = new SqlParameter()
            {
                ParameterName = "@Raza",
                Value = mascota.Raza,
                SqlDbType = SqlDbType.Int
            };
            SqlParameter edadParameter = new SqlParameter()
            {
                ParameterName = "@Edad",
                Value = mascota.Edad,
                SqlDbType = SqlDbType.Int
            };
            SqlParameter vacunasParameter = new SqlParameter()
            {
                ParameterName = "@Vacunas",
                Value = mascota.VacunasAlDia,
                SqlDbType = SqlDbType.Bit
            };
            SqlParameter cedulaParameter = new SqlParameter()
            {
                ParameterName = "@CedulaCliente",
                Value = mascota.CedulaCliente,
                SqlDbType = SqlDbType.BigInt
            };
            command.Parameters.Add(tipoParameter);
            command.Parameters.Add(nombreParameter);
            command.Parameters.Add(razaParameter);
            command.Parameters.Add(edadParameter);
            command.Parameters.Add(vacunasParameter);
            command.Parameters.Add(cedulaParameter);

            int id = (int)command.ExecuteScalar();

            DAOCarnetInscripcion daoCarnetInscripcion = new DAOCarnetInscripcion();
            daoCarnetInscripcion.Add(connection, mascota.CarnetInscripcion.Foto, id);
        }
        #endregion

        #region Consultar existencia de Mascota
        public bool Member(SqlConnection connection, int id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM mascota WHERE id = @Id", connection);
            SqlParameter idParameter = new SqlParameter()
            {
                ParameterName = "@Id",
                Value = id,
                SqlDbType = SqlDbType.Int
            };
            command.Parameters.Add(idParameter);

            SqlDataReader myReader = command.ExecuteReader();
            bool res = myReader.Read() ? true : false;
            myReader.Close();
            return res;
        }
        #endregion

        #region Editar Mascota
        public void Edit(SqlConnection connection, Mascota mascota)
        {
            SqlCommand command = new SqlCommand("UPDATE mascota SET tipo = @Tipo, nombre = @Nombre, raza=@Raza, edad=@Edad, vacunas=@Vacunas, cedulaCliente=@CedulaCliente WHERE id = @Id", connection);
            SqlParameter tipoParameter = new SqlParameter()
            {
                ParameterName = "@Tipo",
                Value = mascota.TipoAnimal,
                SqlDbType = SqlDbType.Int
            };
            SqlParameter nombreParameter = new SqlParameter()
            {
                ParameterName = "@Nombre",
                Value = mascota.Nombre,
                SqlDbType = SqlDbType.VarChar
            };
            SqlParameter razaParameter = new SqlParameter()
            {
                ParameterName = "@Raza",
                Value = mascota.Raza,
                SqlDbType = SqlDbType.Int
            };
            SqlParameter edadParameter = new SqlParameter()
            {
                ParameterName = "@Edad",
                Value = mascota.Edad,
                SqlDbType = SqlDbType.Int
            };
            SqlParameter vacunasParameter = new SqlParameter()
            {
                ParameterName = "@Vacunas",
                Value = mascota.VacunasAlDia,
                SqlDbType = SqlDbType.Bit
            };
            SqlParameter idParameter = new SqlParameter()
            {
                ParameterName = "@Id",
                Value = mascota.Id,
                SqlDbType = SqlDbType.Int
            };
            SqlParameter cedulaParameter = new SqlParameter()
            {
                ParameterName = "@CedulaCliente",
                Value = mascota.CedulaCliente,
                SqlDbType = SqlDbType.BigInt
            };
            command.Parameters.Add(tipoParameter);
            command.Parameters.Add(nombreParameter);
            command.Parameters.Add(razaParameter);
            command.Parameters.Add(edadParameter);
            command.Parameters.Add(vacunasParameter);
            command.Parameters.Add(idParameter);
            command.Parameters.Add(cedulaParameter);

            command.ExecuteNonQuery();
        }
        #endregion

        #region Eliminar Mascota
        public void Delete(SqlConnection connection, int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM mascota WHERE id = @Id", connection);
            SqlParameter idParameter = new SqlParameter()
            {
                ParameterName = "@Id",
                Value = id,
                SqlDbType = SqlDbType.Int
            };
            command.Parameters.Add(idParameter);

            command.ExecuteNonQuery();
        }
        #endregion
    }
}

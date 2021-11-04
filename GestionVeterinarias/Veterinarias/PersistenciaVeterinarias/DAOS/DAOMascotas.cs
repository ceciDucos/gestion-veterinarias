using System.Data;
using System.Data.SqlClient;
using ModelosVeterinarias.Classes;

namespace PersistenciaVeterinarias.DAOS
{
    public class DAOMascotas
    {
        public DAOMascotas() { }

        #region Agregar una Mascota
        public void Add(SqlConnection connection, Mascota mascota)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Mascotas (tipo, nombre, raza, edad, vacunas) VALUES (@Tipo, @Nombre, @Raza, @Edad, @Vacunas)", connection);
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
            command.Parameters.Add(tipoParameter);
            command.Parameters.Add(nombreParameter);
            command.Parameters.Add(razaParameter);
            command.Parameters.Add(edadParameter);
            command.Parameters.Add(vacunasParameter);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        #endregion

        #region Consultar existencia de Mascota
        public bool Member(SqlConnection connection, int id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Mascotas WHERE id = @Id", connection);
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
            SqlCommand command = new SqlCommand("UPDATE Mascotas SET tipo = @Tipo, nombre = @Nombre, raza=@Raza, edad=@Edad, vacunas=@Vacunas WHERE id = @Id", connection);
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
            command.Parameters.Add(tipoParameter);
            command.Parameters.Add(nombreParameter);
            command.Parameters.Add(razaParameter);
            command.Parameters.Add(edadParameter);
            command.Parameters.Add(vacunasParameter);
            command.Parameters.Add(idParameter);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        #endregion

        #region Eliminar Mascota
        public void Delete(SqlConnection connection, int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Mascotas WHERE id = @Id", connection);
            SqlParameter idParameter = new SqlParameter()
            {
                ParameterName = "@Id",
                Value = id,
                SqlDbType = SqlDbType.Int
            };
            command.Parameters.Add(idParameter);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        #endregion
    }
}

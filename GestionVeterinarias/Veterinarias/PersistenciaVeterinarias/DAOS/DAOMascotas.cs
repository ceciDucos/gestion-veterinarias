using System.Data;
using System.Data.SqlClient;
using ModelosVeterinarias.Classes;
using System;
using ModelosVeterinarias.ValueObject;
using System.Collections.Generic;
using System.Text;

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

        public List<VOMascota> List(SqlConnection connection, long Incedula)
        {


            List<VOMascota> listMascotas = new List<VOMascota>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select m.id, m.cedulaCliente, m.tipo, m.nombre, m.edad, m.raza, m.vacunas, c.numero, c.expedido, c.foto");
            sb.Append(" from Mascota m, carnetInscripcion c");
            sb.Append(" where m.id = c.idMascota ");
            sb.AppendFormat(" and m.cedulaCliente = @CedulaCliente");

            SqlCommand selectCommand = new SqlCommand(sb.ToString(), connection);
            SqlParameter cedulaClienteParameter = new SqlParameter()
            {
                ParameterName = "@CedulaCliente",
                Value = Incedula,
                SqlDbType = SqlDbType.BigInt
            };
            selectCommand.Parameters.Add(cedulaClienteParameter);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = selectCommand;

            // creo y cargo el dataset
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Mascota");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(dr["id"]);
                long cedula = Convert.ToInt32(dr["cedulaCliente"]);
                TipoAnimal tipo = (TipoAnimal)Enum.Parse(typeof(TipoAnimal), Convert.ToString(dr["tipo"]));
                string nombre = Convert.ToString(dr["nombre"]);
                int edad = Convert.ToInt32(dr["edad"]);
                Raza raza = (Raza)Enum.Parse(typeof(Raza), Convert.ToString(dr["raza"]));
                bool vacunas = Convert.ToBoolean(dr["vacunas"]);

                // datos para el carne 
                int numero = Convert.ToInt32(dr["numero"]);
                DateTime expedido = Convert.ToDateTime(dr["expedido"]);
                byte[] foto = (byte[])dr["foto"];

                VOCarnetInscripcion vocarnet = new VOCarnetInscripcion(numero, expedido, foto);

                VOMascota vomascota = new VOMascota(id, cedula, tipo, nombre, raza, edad, vacunas, vocarnet);

                listMascotas.Add(vomascota);
            }

            return listMascotas;
        }

        public VOMascota Get(SqlConnection connection, int idToFind)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select m.id, m.cedulaCliente, m.tipo, m.nombre, m.edad, m.raza, m.vacunas, c.numero, c.expedido, c.foto");
            sb.Append(" from Mascota m, carnetInscripcion c");
            sb.Append(" where m.id = c.idMascota ");
            sb.AppendFormat(" and m.id = @IdMascota");

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
            adapter.Fill(ds, "Mascota");
            VOMascota vomascota = null;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(dr["id"]);
                long cedula = Convert.ToInt32(dr["cedulaCliente"]);
                TipoAnimal tipo = (TipoAnimal)Enum.Parse(typeof(TipoAnimal), Convert.ToString(dr["tipo"]));
                string nombre = Convert.ToString(dr["nombre"]);
                int edad = Convert.ToInt32(dr["edad"]);
                Raza raza = (Raza)Enum.Parse(typeof(Raza), Convert.ToString(dr["raza"]));
                bool vacunas = Convert.ToBoolean(dr["vacunas"]);


                // datos para el carne 
                int numero = Convert.ToInt32(dr["numero"]);
                DateTime expedido = Convert.ToDateTime(dr["expedido"]);
                VOCarnetInscripcion vocarnet = new VOCarnetInscripcion(numero, expedido);

                vomascota = new VOMascota(id, cedula, tipo, nombre, raza, edad, vacunas, vocarnet);
            }

            return vomascota;

        }
    }
}

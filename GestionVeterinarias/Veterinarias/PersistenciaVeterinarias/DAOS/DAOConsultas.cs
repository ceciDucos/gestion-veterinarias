﻿using System.Text;
using System.Data.SqlClient;
using System.Data;
using System;
using ModelosVeterinarias.Classes;

namespace PersistenciaVeterinarias.DAOS
{
    public class DAOConsultas
    {
        public DAOConsultas() {}

        public bool Member(SqlConnection connection, int idMascota, DateTime fechaConsulta)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Consulta WHERE ");
            sb.Append("idMascota = @IdMascota AND fecha = @FechaConsulta;");
            SqlCommand command = new SqlCommand(sb.ToString(), connection);

            SqlParameter IdMascotaParameter = new SqlParameter()
            {
                ParameterName = "@IdMascota",
                Value = idMascota,
                SqlDbType = SqlDbType.Int
            };

            SqlParameter FechaConsultaParameter = new SqlParameter()
            {
                ParameterName = "@FechaConsulta",
                Value = fechaConsulta,
                SqlDbType = SqlDbType.DateTime
            };

            command.Parameters.Add(IdMascotaParameter);
            command.Parameters.Add(FechaConsultaParameter);

            SqlDataReader myReader = command.ExecuteReader();
            bool res = myReader.Read() ? true : false;
            myReader.Close();
            return res;
        }

        public bool MemberId(SqlConnection connection, int numero) {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Consulta WHERE ");
            sb.Append("numero = @Numero;");
            SqlCommand command = new SqlCommand(sb.ToString(), connection);

            SqlParameter NumeroParameter = new SqlParameter()
            {
                ParameterName = "@Numero",
                Value = numero,
                SqlDbType = SqlDbType.Int
            };

            command.Parameters.Add(NumeroParameter);

            SqlDataReader myReader = command.ExecuteReader();
            bool res = myReader.Read() ? true : false;
            myReader.Close();
            return res;
        }
        public void Add(SqlConnection connection, Consulta consulta) 
        {
            StringBuilder sbConsulta = new StringBuilder();
            sbConsulta.Append("SET IDENTITY_INSERT Consulta ON ");
            sbConsulta.Append("INSERT INTO Consulta(numero, calificacion, fecha, descripcion, idMascota) ");
            sbConsulta.Append("VALUES (@Numero, @Calificacion, @Fecha, @Descripcion, @IdMascota);");

            SqlCommand commandConsulta = new SqlCommand(sbConsulta.ToString(), connection);

            SqlParameter NumeroParameter = new SqlParameter()
            {
                ParameterName = "@Numero",
                Value = consulta.Numero,
                SqlDbType = SqlDbType.Int
            };

            SqlParameter CalificacionParameter = new SqlParameter()
            {
                ParameterName = "@Calificacion",
                Value = consulta.Calificacion,
                SqlDbType = SqlDbType.Int
            };

            SqlParameter FechaParameter = new SqlParameter()
            {
                ParameterName = "@Fecha",
                Value = consulta.Fecha,
                SqlDbType = SqlDbType.DateTime
            };

            SqlParameter DescripcionParameter = new SqlParameter()
            {
                ParameterName = "@Descripcion",
                Value = consulta.Descripcion,
                SqlDbType = SqlDbType.VarChar
            };

            SqlParameter IdMascotaParameter = new SqlParameter()
            {
                ParameterName = "@IdMascota",
                Value = consulta.Mascota.Id,
                SqlDbType = SqlDbType.Int
            };

            commandConsulta.Parameters.Add(NumeroParameter);
            commandConsulta.Parameters.Add(CalificacionParameter);
            commandConsulta.Parameters.Add(FechaParameter);
            commandConsulta.Parameters.Add(DescripcionParameter);
            commandConsulta.Parameters.Add(IdMascotaParameter);

            commandConsulta.ExecuteNonQuery();
        }

        public void Remove(SqlConnection connection, int numero) 
        {
            SqlCommand commandConsulta = new SqlCommand($"DELETE FROM Consulta WHERE Numero = @Numero", connection);
            SqlParameter NumeroParameter = new SqlParameter()
            {
                ParameterName = "@Numero",
                Value = numero,
                SqlDbType = SqlDbType.Int
            };

            commandConsulta.Parameters.Add(NumeroParameter);
            commandConsulta.ExecuteNonQuery();
        }

        public void Edit(SqlConnection connection, Consulta consulta)
        {

            StringBuilder sbConsulta = new StringBuilder();
            sbConsulta.Append("UPDATE Consulta SET calificacion = @Calificacion, fecha = @Fecha, ");
            sbConsulta.Append("descripcion = @Descripcion, IdMascota = @IdMascota ");
            sbConsulta.Append("WHERE numero = @Numero;");

            SqlCommand commandConsulta = new SqlCommand(sbConsulta.ToString(), connection);

            SqlParameter CalificacionParameter = new SqlParameter()
            {
                ParameterName = "@Calificacion",
                Value = consulta.Calificacion,
                SqlDbType = SqlDbType.Int
            };

            SqlParameter FechaParameter = new SqlParameter()
            {
                ParameterName = "@Fecha",
                Value = consulta.Fecha,
                SqlDbType = SqlDbType.DateTime
            };

            SqlParameter DescripcionParameter = new SqlParameter()
            {
                ParameterName = "@Descripcion",
                Value = consulta.Descripcion,
                SqlDbType = SqlDbType.VarChar
            };

            SqlParameter IdMascotaParameter = new SqlParameter()
            {
                ParameterName = "@IdMascota",
                Value = consulta.Mascota.Id,
                SqlDbType = SqlDbType.Int
            };

            SqlParameter NumeroParameter = new SqlParameter()
            {
                ParameterName = "@Numero",
                Value = consulta.Numero,
                SqlDbType = SqlDbType.Int
            };

            commandConsulta.Parameters.Add(CalificacionParameter);
            commandConsulta.Parameters.Add(FechaParameter);
            commandConsulta.Parameters.Add(DescripcionParameter);
            commandConsulta.Parameters.Add(IdMascotaParameter);
            commandConsulta.Parameters.Add(NumeroParameter);

            commandConsulta.ExecuteNonQuery();
        }
    }
}

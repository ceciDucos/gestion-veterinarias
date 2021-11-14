using ModelosVeterinarias.Classes;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System;
using ModelosVeterinarias.ValueObject;
using System.Collections.Generic;
using PersistenciaVeterinarias.DAOS;

public class DAOConsultas
{
    private DAOMascotas daomascotas = new DAOMascotas();
    public DAOConsultas() { }

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

    public bool MemberId(SqlConnection connection, int numero)
    {
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
        sbConsulta.Append("INSERT INTO Consulta(calificacion, fecha, descripcion, idMascota) ");
        sbConsulta.Append("VALUES (@Calificacion, @Fecha, @Descripcion, @IdMascota);");

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

    public void SetCalification(SqlConnection connection, int numero, int calificacion)
    {
        StringBuilder sbConsulta = new StringBuilder();
        sbConsulta.Append("UPDATE Consulta SET calificacion = @Calificacion ");
        sbConsulta.Append("WHERE numero = @Numero;");

        SqlCommand commandConsulta = new SqlCommand(sbConsulta.ToString(), connection);

        SqlParameter NumeroParameter = new SqlParameter()
        {
            ParameterName = "@Numero",
            Value = numero,
            SqlDbType = SqlDbType.Int
        };

        SqlParameter CalificacionParameter = new SqlParameter()
        {
            ParameterName = "@Calificacion",
            Value = calificacion,
            SqlDbType = SqlDbType.Int
        };

        commandConsulta.Parameters.Add(NumeroParameter);
        commandConsulta.Parameters.Add(CalificacionParameter);

        commandConsulta.ExecuteNonQuery();
    }

    public List<VOConsulta> ListByMascota(SqlConnection connection, int idMascota)
    {
        List<VOConsulta> listConsultas = new List<VOConsulta>();

        StringBuilder sb = new StringBuilder();
        sb.Append("select c.numero, c.calificacion, c.fecha, c.descripcion, c.idMascota");
        sb.Append(" from Consulta c");
        sb.Append(" where c.idMascota = @IdMascota");

        SqlCommand selectCommand = new SqlCommand(sb.ToString(), connection);

        SqlParameter IdVeterinariaParameter = new SqlParameter()
        {
            ParameterName = "@IdMascota",
            Value = idMascota,
            SqlDbType = SqlDbType.Int
        };
        selectCommand.Parameters.Add(IdVeterinariaParameter);

        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = selectCommand;

        // creo y cargo el dataset
        DataSet ds = new DataSet();
        adapter.Fill(ds, "Consulta");
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            int numero = Convert.ToInt32(dr["numero"]);
            int calificacion = Convert.ToInt32(dr["calificacion"]);
            DateTime fecha = Convert.ToDateTime(dr["fecha"]);
            string descripcion = Convert.ToString(dr["descripcion"]);

            VOMascota mascota = daomascotas.Get(connection, idMascota);

            VOConsulta voconsulta = new VOConsulta(numero, fecha, descripcion, calificacion, mascota);

            listConsultas.Add(voconsulta);
        }

        return listConsultas;
    }

    public List<VOConsulta> ListByVeterinaria(SqlConnection connection, int idVeterinaria)
    {
        List<VOConsulta> listConsultas = new List<VOConsulta>();

        StringBuilder sb = new StringBuilder();
        sb.Append("select c.numero, c.calificacion, c.fecha, c.descripcion, c.idMascota");
        sb.Append(" from Consulta c, Mascota m, Persona p");
        sb.Append(" where c.idMascota = m.id and m.cedulaCliente = p.cedula and p.idVeterinaria = @IdVeterinaria;");

        SqlCommand selectCommand = new SqlCommand(sb.ToString(), connection);

        SqlParameter IdVeterinariaParameter = new SqlParameter()
        {
            ParameterName = "@IdVeterinaria",
            Value = idVeterinaria,
            SqlDbType = SqlDbType.Int
        };
        selectCommand.Parameters.Add(IdVeterinariaParameter);

        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = selectCommand;

        // creo y cargo el dataset
        DataSet ds = new DataSet();
        adapter.Fill(ds, "Consulta");
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            int numero = Convert.ToInt32(dr["numero"]);
            int calificacion = Convert.ToInt32(dr["calificacion"]);
            DateTime fecha = Convert.ToDateTime(dr["fecha"]);
            string descripcion = Convert.ToString(dr["descripcion"]);
            int idMascota = Convert.ToInt32(dr["idMascota"]);

            VOMascota mascota = daomascotas.Get(connection, idMascota);

            VOConsulta voconsulta = new VOConsulta(numero, fecha, descripcion, calificacion, mascota);

            listConsultas.Add(voconsulta);
        }

        return listConsultas;
    }
}

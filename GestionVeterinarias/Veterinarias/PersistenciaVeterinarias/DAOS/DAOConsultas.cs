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
    private DAOVeterinarios daoveterinario = new DAOVeterinarios();
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
        sbConsulta.Append("INSERT INTO Consulta(calificacion, fecha, descripcion, idMascota, idVeterinario, realizada, importe) ");
        sbConsulta.Append("VALUES (@Calificacion, @Fecha, @Descripcion, @IdMascota, @IdVeterinario, @Realizada, @Importe);");

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

        SqlParameter IdVeterinarioParameter = new SqlParameter()
        {
            ParameterName = "@IdVeterinario",
            Value = consulta.Veterinario.Cedula,
            SqlDbType = SqlDbType.Int
        };

        SqlParameter RealizadaParameter = new SqlParameter()
        {
            ParameterName = "@Realizada",
            Value = consulta.Realizada,
            SqlDbType = SqlDbType.Bit
        };

        SqlParameter ImporteParameter = new SqlParameter()
        {
            ParameterName = "@Importe",
            Value = consulta.Importe,
            SqlDbType = SqlDbType.Int
        };

        commandConsulta.Parameters.Add(CalificacionParameter);
        commandConsulta.Parameters.Add(FechaParameter);
        commandConsulta.Parameters.Add(DescripcionParameter);
        commandConsulta.Parameters.Add(IdMascotaParameter);
        commandConsulta.Parameters.Add(IdVeterinarioParameter);
        commandConsulta.Parameters.Add(RealizadaParameter);
        commandConsulta.Parameters.Add(ImporteParameter);

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
        sbConsulta.Append("descripcion = @Descripcion, IdMascota = @IdMascota, IdVeterinario = @IdVeterinario, ");
        sbConsulta.Append("realizada = @Realizada, importe = @Importe ");
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

        SqlParameter IdVeterinarioParameter = new SqlParameter()
        {
            ParameterName = "@IdVeterinario",
            Value = consulta.Veterinario.Cedula,
            SqlDbType = SqlDbType.Int
        };

        SqlParameter RealizadaParameter = new SqlParameter()
        {
            ParameterName = "@Realizada",
            Value = consulta.Realizada,
            SqlDbType = SqlDbType.Bit
        };

        SqlParameter ImporteParameter = new SqlParameter()
        {
            ParameterName = "@Importe",
            Value = consulta.Importe,
            SqlDbType = SqlDbType.Bit
        };

        commandConsulta.Parameters.Add(CalificacionParameter);
        commandConsulta.Parameters.Add(FechaParameter);
        commandConsulta.Parameters.Add(DescripcionParameter);
        commandConsulta.Parameters.Add(IdMascotaParameter);
        commandConsulta.Parameters.Add(NumeroParameter);
        commandConsulta.Parameters.Add(IdVeterinarioParameter);
        commandConsulta.Parameters.Add(RealizadaParameter);
        commandConsulta.Parameters.Add(ImporteParameter);

        commandConsulta.ExecuteNonQuery();
    }

    public void SetCalification(SqlConnection connection, long cedula, int numero, int calificacion)
    {
        StringBuilder sbConsulta = new StringBuilder();
        sbConsulta.Append("UPDATE Consulta SET calificacion = @Calificacion ");
        sbConsulta.Append("FROM Consulta co, Mascota ma ");
        sbConsulta.Append("WHERE co.numero = @Numero and co.idMascota = ma.id and ma.cedulaCliente = @Cedula;");

        SqlCommand commandConsulta = new SqlCommand(sbConsulta.ToString(), connection);


        SqlParameter CedulaParameter = new SqlParameter()
        {
            ParameterName = "@Cedula",
            Value = cedula,
            SqlDbType = SqlDbType.BigInt
        };

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

        commandConsulta.Parameters.Add(CedulaParameter);
        commandConsulta.Parameters.Add(NumeroParameter);
        commandConsulta.Parameters.Add(CalificacionParameter);

        commandConsulta.ExecuteNonQuery();
    }

    public List<VOConsulta> ListByMascota(SqlConnection connection, int idMascota)
    {
        List<VOConsulta> listConsultas = new List<VOConsulta>();

        StringBuilder sb = new StringBuilder();
        sb.Append("select *");
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
            int calificacion = Convert.ToInt32(dr["calificacion"]);//0;
            DateTime fecha = Convert.ToDateTime(dr["fecha"]);
            string descripcion = Convert.ToString(dr["descripcion"]);
            int idVeterinario = Convert.ToInt32(dr["IdVeterinario"]);
            bool realizada = Convert.ToBoolean(dr["realizada"]);
            double importe = Convert.ToDouble(dr["importe"]);

            VOMascota mascota = daomascotas.Get(connection, idMascota);
            VOVeterinario veterinario = daoveterinario.Get(connection, idVeterinario);

            VOConsulta voconsulta = new VOConsulta(numero, fecha, descripcion, calificacion, mascota, veterinario, realizada, importe);

            listConsultas.Add(voconsulta);
        }

        return listConsultas;
    }

    public List<VOConsulta> ListByVeterinaria(SqlConnection connection, int idVeterinaria)
    {
        List<VOConsulta> listConsultas = new List<VOConsulta>();

        StringBuilder sb = new StringBuilder();
        sb.Append("select c.numero, c.calificacion, c.fecha, c.descripcion, c.idMascota, c.idVeterinario, c.realizada, c.importe");
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
            int calificacion = Convert.ToInt32(dr["calificacion"]); //0;
            DateTime fecha = Convert.ToDateTime(dr["fecha"]);
            string descripcion = Convert.ToString(dr["descripcion"]);
            int idMascota = Convert.ToInt32(dr["idMascota"]);
            int idVeterinario = Convert.ToInt32(dr["IdVeterinario"]);
            bool realizada = Convert.ToBoolean(dr["realizada"]);
            double importe = Convert.ToDouble(dr["importe"]);

            VOMascota mascota = daomascotas.Get(connection, idMascota);
            VOVeterinario veterinario = daoveterinario.Get(connection, idVeterinario);

            VOConsulta voconsulta = new VOConsulta(numero, fecha, descripcion, calificacion, mascota, veterinario, realizada, importe);

            listConsultas.Add(voconsulta);
        }

        return listConsultas;
    }

    public List<VOConsulta> ListByVeterinariaByDate(SqlConnection connection, int idVeterinaria, DateTime desde, DateTime hasta)
    {
        List<VOConsulta> listConsultas = new List<VOConsulta>();

        StringBuilder sb = new StringBuilder();
        sb.Append("select c.numero, c.calificacion, c.fecha, c.descripcion, c.idMascota, c.idVeterinario, c.realizada, c.importe");
        sb.Append(" from Consulta c, Mascota m, Persona p");
        sb.Append(" where c.idMascota = m.id and m.cedulaCliente = p.cedula and p.idVeterinaria = @IdVeterinaria");
        sb.Append(" and c.fecha >= @Desde and c.fecha <= @Hasta;");

        SqlCommand selectCommand = new SqlCommand(sb.ToString(), connection);

        SqlParameter IdVeterinariaParameter = new SqlParameter()
        {
            ParameterName = "@IdVeterinaria",
            Value = idVeterinaria,
            SqlDbType = SqlDbType.Int
        };

        SqlParameter DesdeParameter = new SqlParameter()
        {
            ParameterName = "@Desde",
            Value = desde,
            SqlDbType = SqlDbType.DateTime
        };

        SqlParameter HastaParameter = new SqlParameter()
        {
            ParameterName = "@Hasta",
            Value = hasta,
            SqlDbType = SqlDbType.DateTime
        };
        selectCommand.Parameters.Add(IdVeterinariaParameter);
        selectCommand.Parameters.Add(DesdeParameter);
        selectCommand.Parameters.Add(HastaParameter);

        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = selectCommand;

        // creo y cargo el dataset
        DataSet ds = new DataSet();
        adapter.Fill(ds, "Consulta");
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            int numero = Convert.ToInt32(dr["numero"]);
            int calificacion = Convert.ToInt32(dr["calificacion"]); //0;
            DateTime fecha = Convert.ToDateTime(dr["fecha"]);
            string descripcion = Convert.ToString(dr["descripcion"]);
            int idMascota = Convert.ToInt32(dr["idMascota"]);
            int idVeterinario = Convert.ToInt32(dr["IdVeterinario"]);
            bool realizada = Convert.ToBoolean(dr["realizada"]);
            double importe = Convert.ToDouble(dr["importe"]);

            VOMascota mascota = daomascotas.Get(connection, idMascota);
            VOVeterinario veterinario = daoveterinario.Get(connection, idVeterinario);

            VOConsulta voconsulta = new VOConsulta(numero, fecha, descripcion, calificacion, mascota, veterinario, realizada, importe);

            listConsultas.Add(voconsulta);
        }

        return listConsultas;
    }

    public List<VOConsulta> ListByVeterinario(SqlConnection connection, long cedulaCliente, DateTime desde, DateTime hasta)
    {
        List<VOConsulta> listConsultas = new List<VOConsulta>();

        StringBuilder sb = new StringBuilder();
        sb.Append("select *");
        sb.Append(" from Consulta c");
        sb.Append(" where c.idVeterinario = @cedulaCliente");
        sb.Append(" and c.fecha >= @Desde and c.fecha <= @Hasta;");

        SqlCommand selectCommand = new SqlCommand(sb.ToString(), connection);

        SqlParameter CedulaVeterinarioParameter = new SqlParameter()
        {
            ParameterName = "@cedulaCliente",
            Value = cedulaCliente,
            SqlDbType = SqlDbType.BigInt
        };

        SqlParameter DesdeParameter = new SqlParameter()
        {
            ParameterName = "@Desde",
            Value = desde,
            SqlDbType = SqlDbType.DateTime
        };

        SqlParameter HastaParameter = new SqlParameter()
        {
            ParameterName = "@Hasta",
            Value = hasta,
            SqlDbType = SqlDbType.DateTime
        };
        selectCommand.Parameters.Add(DesdeParameter);
        selectCommand.Parameters.Add(HastaParameter);
        selectCommand.Parameters.Add(CedulaVeterinarioParameter);

        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = selectCommand;

        // creo y cargo el dataset
        DataSet ds = new DataSet();
        adapter.Fill(ds, "Consulta");
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            int numero = Convert.ToInt32(dr["numero"]);
            int calificacion = Convert.ToInt32(dr["calificacion"]); //0;
            DateTime fecha = Convert.ToDateTime(dr["fecha"]);
            string descripcion = Convert.ToString(dr["descripcion"]);
            int idMascota = Convert.ToInt32(dr["idMascota"]);
            bool realizada = Convert.ToBoolean(dr["realizada"]);
            double importe = Convert.ToDouble(dr["importe"]);

            VOMascota mascota = daomascotas.Get(connection, idMascota);
            VOVeterinario veterinario = daoveterinario.Get(connection, cedulaCliente);

            VOConsulta voconsulta = new VOConsulta(numero, fecha, descripcion, calificacion, mascota, veterinario, realizada, importe);

            listConsultas.Add(voconsulta);
        }

        return listConsultas;
    }

    public VOConsulta Get(SqlConnection connection, int InNumero)
    {


        StringBuilder sb = new StringBuilder();
        sb.Append("select *");
        sb.Append(" from Consulta");
        sb.AppendFormat(" where numero = {0}", InNumero.ToString());

        SqlCommand selectCommand = new SqlCommand(sb.ToString(), connection);

        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = selectCommand;

        DataSet ds = new DataSet();
        adapter.Fill(ds, "Consulta");
        VOConsulta voconsulta = null;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            int numero = Convert.ToInt32(dr["numero"]);
            int calificacion = Convert.ToInt32(dr["calificacion"]); //0;
            DateTime fecha = Convert.ToDateTime(dr["fecha"]);
            string descripcion = Convert.ToString(dr["descripcion"]);
            int idMascota = Convert.ToInt32(dr["idMascota"]);
            int idVeterinario = Convert.ToInt32(dr["IdVeterinario"]);
            bool realizada = Convert.ToBoolean(dr["realizada"]);
            double importe = Convert.ToDouble(dr["importe"]);
            VOMascota mascota = daomascotas.Get(connection, idMascota);
            VOVeterinario veterinario = daoveterinario.Get(connection, idVeterinario);

            voconsulta = new VOConsulta(numero, fecha, descripcion, calificacion, mascota, veterinario, realizada, importe);


        }

        return voconsulta;
    }

    public List<VOConsulta> ListByCliente(SqlConnection connection, int cedulaCliente)
    {
        List<VOConsulta> listConsultas = new List<VOConsulta>();

        StringBuilder sb = new StringBuilder();
        sb.Append("select c.numero, c.calificacion, c.fecha, c.descripcion, c.idMascota, c.idVeterinario, c.realizada, c.importe");
        sb.Append(" from Consulta c, Mascota m, Cliente cl");
        sb.Append(" where c.idMascota = m.id and m.cedulaCliente = cl.cedula and cl.cedula = @CedulaCliente;");

        SqlCommand selectCommand = new SqlCommand(sb.ToString(), connection);

        SqlParameter IdVeterinariaParameter = new SqlParameter()
        {
            ParameterName = "@CedulaCliente",
            Value = cedulaCliente,
            SqlDbType = SqlDbType.BigInt
        };
        selectCommand.Parameters.Add(IdVeterinariaParameter);

        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = selectCommand;

        DataSet ds = new DataSet();
        adapter.Fill(ds, "Consulta");
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            int numero = Convert.ToInt32(dr["numero"]);
            int calificacion = Convert.ToInt32(dr["calificacion"]);
            DateTime fecha = Convert.ToDateTime(dr["fecha"]);
            string descripcion = Convert.ToString(dr["descripcion"]);
            int idMascota = Convert.ToInt32(dr["idMascota"]);
            int idVeterinario = Convert.ToInt32(dr["IdVeterinario"]);
            bool realizada = Convert.ToBoolean(dr["realizada"]);
            double importe = Convert.ToDouble(dr["importe"]);

            VOMascota mascota = daomascotas.Get(connection, idMascota);
            VOVeterinario veterinario = daoveterinario.Get(connection, idVeterinario);

            VOConsulta voconsulta = new VOConsulta(numero, fecha, descripcion, calificacion, mascota, veterinario, realizada, importe);

            listConsultas.Add(voconsulta);
        }

        return listConsultas;
    }
}

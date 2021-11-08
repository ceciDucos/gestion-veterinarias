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
    public class DAOSistema
    {
        public DAOSistema() { }

        public void CrearDB(SqlConnection connection) {
            string query =
            @"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'gestion_veterinarias')
                BEGIN
                  CREATE DATABASE gestion_veterinarias;
                END;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            
        }

        public void CrearTablas(SqlConnection connection)
        {
            string query_persona =
                @"IF NOT EXISTS
                   (  SELECT [name]
                      FROM sys.tables
                      WHERE [name] = 'persona'
                   )CREATE TABLE [gestion_veterinarias].[dbo].persona(
                    cedula int NOT NULL,
                    nombre varchar(128) NOT NULL,
                    telefono  varchar(128),
                    PRIMARY KEY(cedula),
                );";
            SqlCommand cmd = new SqlCommand(query_persona, connection);
            cmd.ExecuteNonQuery();

            string query_veterinario =
                @"IF NOT EXISTS
                   (  SELECT [name]
                      FROM sys.tables
                      WHERE [name] = 'veterinario'
                   )
                CREATE TABLE [gestion_veterinarias].[dbo].veterinario (
                                    cedula int NOT NULL,
                                    horario varchar(128) NOT NULL,
                                    FOREIGN KEY (cedula) REFERENCES [gestion_veterinarias].[dbo].persona(cedula)
                                );";
            cmd = new SqlCommand(query_veterinario, connection);
            cmd.ExecuteNonQuery();


            string query_cliente =
                @"IF NOT EXISTS
                   (  SELECT [name]
                      FROM sys.tables
                      WHERE [name] = 'cliente'
                )
                CREATE TABLE [gestion_veterinarias].[dbo].cliente (
                    cedula int NOT NULL,
                    direccion varchar(128) ,
                    correo varchar(128),
                    pass varchar(128),
                    activo bit,
                    FOREIGN KEY (cedula) REFERENCES [gestion_veterinarias].[dbo].persona(cedula)
                );";
            cmd = new SqlCommand(query_cliente, connection);
            cmd.ExecuteNonQuery();

            connection.Close();

        }

        public void CargarDatos(SqlConnection connection)
        {
            string query =
            @"INSERT INTO[gestion_veterinarias].[dbo].persona(cedula, nombre, telefono)
                VALUES(42209587, 'Rodrigo', '099844667');";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query =
            @"INSERT INTO [gestion_veterinarias].[dbo].veterinario (cedula,horario)
            VALUES (42209587, 'L-V 10:18');";
            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            query =
            @"INSERT INTO [gestion_veterinarias].[dbo].persona (cedula,nombre,telefono)
            VALUES (1234567, 'Carolina', '099123456');

            INSERT INTO [gestion_veterinarias].[dbo].veterinario (cedula,horario)
            VALUES (1234567, 'L-m 10:12');";
            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();


            Console.WriteLine("Cargardo ok");
        }

    }
    
}

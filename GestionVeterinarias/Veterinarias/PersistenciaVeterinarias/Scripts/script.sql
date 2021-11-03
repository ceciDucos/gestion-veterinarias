IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'gestion_veterinarias')
BEGIN
  CREATE DATABASE gestion_veterinarias;
END;
GO

CREATE TABLE [gestion_veterinarias].[dbo].persona (
    cedula int NOT NULL,
    nombre varchar(128) NOT NULL,
    telefono  varchar(128),
    PRIMARY KEY (cedula),
);

CREATE TABLE [gestion_veterinarias].[dbo].veterinario (
    cedula int NOT NULL,
    horario varchar(128) NOT NULL,
    FOREIGN KEY (cedula) REFERENCES [gestion_veterinarias].[dbo].persona(cedula)
);


CREATE TABLE [gestion_veterinarias].[dbo].cliente (
    cedula int NOT NULL,
    direccion varchar(128) ,
    correo varchar(128),
    pass varchar(128),
    activo bit,
    FOREIGN KEY (cedula) REFERENCES [gestion_veterinarias].[dbo].persona(cedula)
);

CREATE TABLE [gestion_veterinarias].[dbo].[Mascotas](
	id int IDENTITY(1,1) NOT NULL,
	tipo int NULL,
	nombre varchar(50) NULL,
	raza int NULL,
	edad int NULL,
	vacunas bit NULL,
	PRIMARY KEY (id),
);
-- ---------------------------------- DATOS INICIALES ----------------------------------

INSERT INTO [gestion_veterinarias].[dbo].persona (cedula,nombre,telefono)
VALUES (42209587, 'Rodrigo', '099844667');

INSERT INTO [gestion_veterinarias].[dbo].veterinario (cedula,horario)
VALUES (42209587, 'L-V 10:18');

INSERT INTO [gestion_veterinarias].[dbo].persona (cedula,nombre,telefono)
VALUES (1234567, 'Carolina', '099123456');

INSERT INTO [gestion_veterinarias].[dbo].veterinario (cedula,horario)
VALUES (1234567, 'L-m 10:12');

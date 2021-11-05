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


CREATE TABLE [gestion_veterinarias].[dbo].mascota (
	id int IDENTITY(1,1) NOT NULL,
	tipo int NULL,
	nombre varchar(50) NULL,
	raza int NULL,
	edad int NULL,
	vacunas bit NULL,
	PRIMARY KEY (id),
);


CREATE TABLE [gestion_veterinarias].[dbo].consulta (
    numero INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    calificacion INT,
    fecha DATETIME,
    descripcion varchar(128),
    idMascota INT,
    FOREIGN KEY (idMascota) REFERENCES [gestion_veterinarias].[dbo].mascota(id)
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

INSERT INTO [gestion_veterinarias].[dbo].persona (cedula,nombre,telefono)
VALUES (88209587, 'Rodrigo', '099844667');

INSERT INTO [gestion_veterinarias].[dbo].persona (cedula,nombre,telefono)
VALUES (11209588, 'Pepe', '099844999');

INSERT INTO [gestion_veterinarias].[dbo].cliente (cedula,direccion,correo,pass,activo)
VALUES (88209587, 'lo de r', 'r@gmail', 'trtr', 1);

INSERT INTO [gestion_veterinarias].[dbo].cliente (cedula,direccion,correo,pass,activo)
VALUES (11209588, 'lo de pepe', 'pepe@gmail', 'pepe1234', 1);

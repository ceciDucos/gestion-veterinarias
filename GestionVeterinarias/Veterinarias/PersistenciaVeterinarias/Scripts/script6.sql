USE [gestion_veterinarias]
GO
/****** Object:  Table [dbo].[carnetInscripcion]    Script Date: 11/19/2021 12:08:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carnetInscripcion](
	[numero] [int] IDENTITY(10000,1) NOT NULL,
	[expedido] [date] NULL,
	[foto] [image] NULL,
	[idMascota] [int] NOT NULL,
 CONSTRAINT [PK_carnetInscripcion] PRIMARY KEY CLUSTERED 
(
	[numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 11/19/2021 12:08:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[cedula] [int] NOT NULL,
	[direccion] [varchar](128) NULL,
	[correo] [varchar](128) NULL,
	[pass] [varchar](128) NULL,
	[activo] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[consulta]    Script Date: 11/19/2021 12:08:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[consulta](
	[numero] [int] IDENTITY(1,1) NOT NULL,
	[calificacion] [int] NULL,
	[fecha] [datetime] NOT NULL,
	[descripcion] [varchar](128) NOT NULL,
	[idMascota] [int] NOT NULL,
	[idVeterinario] [int] NOT NULL,
	[realizada] [bit] NOT NULL,
	[importe] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mascota]    Script Date: 11/19/2021 12:08:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mascota](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [int] NULL,
	[nombre] [varchar](50) NULL,
	[raza] [int] NULL,
	[edad] [int] NULL,
	[vacunas] [bit] NULL,
	[cedulaCliente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[persona]    Script Date: 11/19/2021 12:08:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persona](
	[cedula] [int] NOT NULL,
	[nombre] [varchar](128) NOT NULL,
	[telefono] [varchar](128) NULL,
	[idVeterinaria] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[veterinaria]    Script Date: 11/19/2021 12:08:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[veterinaria](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
 CONSTRAINT [PK_veterinaria] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[veterinario]    Script Date: 11/19/2021 12:08:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[veterinario](
	[cedula] [int] NOT NULL,
	[horario] [varchar](128) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[carnetInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_mascota_carnetInscripcion] FOREIGN KEY([idMascota])
REFERENCES [dbo].[mascota] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[carnetInscripcion] CHECK CONSTRAINT [FK_mascota_carnetInscripcion]
GO
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK__cliente__cedula__4222D4EF] FOREIGN KEY([cedula])
REFERENCES [dbo].[persona] ([cedula])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK__cliente__cedula__4222D4EF]
GO
ALTER TABLE [dbo].[consulta]  WITH CHECK ADD  CONSTRAINT [FK__consulta__idMasc__4316F928] FOREIGN KEY([idMascota])
REFERENCES [dbo].[mascota] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[consulta] CHECK CONSTRAINT [FK__consulta__idMasc__4316F928]
GO
ALTER TABLE [dbo].[consulta]  WITH CHECK ADD FOREIGN KEY([idVeterinario])
REFERENCES [dbo].[persona] ([cedula])
GO
ALTER TABLE [dbo].[mascota]  WITH CHECK ADD  CONSTRAINT [FK__mascota__cedulaC__44FF419A] FOREIGN KEY([cedulaCliente])
REFERENCES [dbo].[persona] ([cedula])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[mascota] CHECK CONSTRAINT [FK__mascota__cedulaC__44FF419A]
GO
ALTER TABLE [dbo].[persona]  WITH CHECK ADD  CONSTRAINT [FK_persona_veterinaria] FOREIGN KEY([idVeterinaria])
REFERENCES [dbo].[veterinaria] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[persona] CHECK CONSTRAINT [FK_persona_veterinaria]
GO
ALTER TABLE [dbo].[veterinario]  WITH CHECK ADD  CONSTRAINT [FK__veterinar__cedul__46E78A0C] FOREIGN KEY([cedula])
REFERENCES [dbo].[persona] ([cedula])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[veterinario] CHECK CONSTRAINT [FK__veterinar__cedul__46E78A0C]
GO

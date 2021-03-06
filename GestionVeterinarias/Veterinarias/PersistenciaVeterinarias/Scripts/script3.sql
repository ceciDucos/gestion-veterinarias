USE [gestion_veterinarias]
GO
/****** Object:  Table [dbo].[carnetInscripcion]    Script Date: 11/14/2021 12:07:44 PM ******/
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
/****** Object:  Table [dbo].[cliente]    Script Date: 11/14/2021 12:07:44 PM ******/
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
/****** Object:  Table [dbo].[consulta]    Script Date: 11/14/2021 12:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[consulta](
	[numero] [int] IDENTITY(1,1) NOT NULL,
	[calificacion] [int] NULL,
	[fecha] [datetime] NULL,
	[descripcion] [varchar](128) NULL,
	[idMascota] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mascota]    Script Date: 11/14/2021 12:07:44 PM ******/
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
/****** Object:  Table [dbo].[persona]    Script Date: 11/14/2021 12:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persona](
	[cedula] [int] NOT NULL,
	[nombre] [varchar](128) NOT NULL,
	[telefono] [varchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[veterinaria]    Script Date: 11/14/2021 12:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[veterinaria](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
	[telefono] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[veterinario]    Script Date: 11/14/2021 12:07:44 PM ******/
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
GO
ALTER TABLE [dbo].[carnetInscripcion] CHECK CONSTRAINT [FK_mascota_carnetInscripcion]
GO
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD FOREIGN KEY([cedula])
REFERENCES [dbo].[persona] ([cedula])
GO
ALTER TABLE [dbo].[consulta]  WITH CHECK ADD FOREIGN KEY([idMascota])
REFERENCES [dbo].[mascota] ([id])
GO
ALTER TABLE [dbo].[mascota]  WITH CHECK ADD FOREIGN KEY([cedulaCliente])
REFERENCES [dbo].[persona] ([cedula])
GO
ALTER TABLE [dbo].[veterinario]  WITH CHECK ADD FOREIGN KEY([cedula])
REFERENCES [dbo].[persona] ([cedula])
GO

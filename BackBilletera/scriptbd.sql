USE [master]
GO
/****** Object:  Database [DSI]    Script Date: 31/10/2022 17:51:41 ******/
CREATE DATABASE [DSI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DSI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DSI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DSI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DSI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DSI] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DSI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DSI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DSI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DSI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DSI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DSI] SET ARITHABORT OFF 
GO
ALTER DATABASE [DSI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DSI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DSI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DSI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DSI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DSI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DSI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DSI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DSI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DSI] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DSI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DSI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DSI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DSI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DSI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DSI] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DSI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DSI] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DSI] SET  MULTI_USER 
GO
ALTER DATABASE [DSI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DSI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DSI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DSI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DSI] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DSI] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DSI] SET QUERY_STORE = OFF
GO
USE [DSI]
GO
/****** Object:  Table [dbo].[AsignacionVisita]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignacionVisita](
	[fechaHoraFin] [nchar](10) NULL,
	[guiaAsignado] [nchar](10) NULL,
	[fechaHoraInicio] [nchar](10) NOT NULL,
	[idReserva] [nchar](10) NOT NULL,
	[idSede] [nchar](10) NOT NULL,
 CONSTRAINT [PK_AsignacionVisita] PRIMARY KEY CLUSTERED 
(
	[fechaHoraInicio] ASC,
	[idReserva] ASC,
	[idSede] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CambioEstado]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CambioEstado](
	[fechaHoraFin] [nchar](10) NULL,
	[fechaHoraInicio] [nchar](10) NOT NULL,
	[ordId] [nchar](10) NOT NULL,
 CONSTRAINT [PK_CambioEstado] PRIMARY KEY CLUSTERED 
(
	[fechaHoraInicio] ASC,
	[ordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleExposicion]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleExposicion](
	[lugarAsignado] [nchar](10) NULL,
	[idObra] [int] NOT NULL,
	[idExposicion] [int] NOT NULL,
	[idSede] [int] NOT NULL,
 CONSTRAINT [PK_DetalleExposicion] PRIMARY KEY CLUSTERED 
(
	[idObra] ASC,
	[idExposicion] ASC,
	[idSede] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[apellido] [nchar](10) NULL,
	[codigoValuacion] [nchar](10) NULL,
	[cuit] [int] NOT NULL,
	[dni] [int] NULL,
	[calle] [nchar](10) NULL,
	[numeroCalle] [int] NULL,
	[fechaIngreso] [date] NULL,
	[fechaNacimiento] [date] NULL,
	[mail] [text] NULL,
	[nombre] [nchar](10) NULL,
	[idSexo] [int] NULL,
	[telefono] [int] NULL,
	[cargo] [int] NULL,
	[idSede] [int] NULL,
	[horaIngreso] [date] NULL,
	[diaSemana] [date] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[cuit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Escuela]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escuela](
	[calle] [nchar](10) NULL,
	[numeroCalle] [nchar](10) NULL,
	[mail] [nchar](10) NULL,
	[nombre] [nchar](10) NULL,
	[telefCelular] [nchar](10) NULL,
	[telefFijo] [nchar](10) NULL,
	[idEscuela] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Escuela] PRIMARY KEY CLUSTERED 
(
	[idEscuela] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exposicion]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exposicion](
	[fechaFin] [nchar](10) NULL,
	[fechaFinReplanificada] [nchar](10) NULL,
	[fechaInicio] [nchar](10) NULL,
	[fechaInicioReplanificacion] [nchar](10) NULL,
	[horaApertura] [nchar](10) NULL,
	[horaCierre] [nchar](10) NULL,
	[nombre] [nchar](10) NULL,
	[idExposicion] [int] NOT NULL,
	[idSede] [int] NOT NULL,
	[idTipoExposicion] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExposicionesXSede]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExposicionesXSede](
	[idSede] [nchar](10) NOT NULL,
	[idExposicion] [nchar](10) NOT NULL,
	[fechaHoraInicio] [nchar](10) NULL,
	[fechaHoraFin] [nchar](10) NULL,
 CONSTRAINT [PK_ExposicionesXSede] PRIMARY KEY CLUSTERED 
(
	[idSede] ASC,
	[idExposicion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HorarioEmpleado]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HorarioEmpleado](
	[horaIngreso] [nchar](10) NOT NULL,
	[horaSemana] [nchar](10) NOT NULL,
	[horaSalida] [nchar](10) NULL,
 CONSTRAINT [PK_HorarioEmpleado] PRIMARY KEY CLUSTERED 
(
	[horaIngreso] ASC,
	[horaSemana] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Obra]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Obra](
	[alto] [int] NULL,
	[ancho] [int] NULL,
	[codigoSensor] [int] NULL,
	[descripcion] [text] NULL,
	[duracionExtenida] [int] NULL,
	[duracionResumida] [int] NULL,
	[fechaCreacion] [date] NULL,
	[fechaPrimerIngreso] [date] NULL,
	[nombreObra] [text] NULL,
	[peso] [int] NULL,
	[valuacion] [int] NULL,
	[idObra] [int] NOT NULL,
	[idExposicion] [int] NULL,
 CONSTRAINT [PK_Obra] PRIMARY KEY CLUSTERED 
(
	[idObra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PublicoDestino]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PublicoDestino](
	[caracteristicas] [nchar](10) NULL,
	[nombre] [nchar](10) NULL,
	[idPublicoDestino] [nchar](10) NOT NULL,
 CONSTRAINT [PK_PublicoDestino] PRIMARY KEY CLUSTERED 
(
	[idPublicoDestino] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservasXSede]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservasXSede](
	[numeroReserva] [nchar](10) NOT NULL,
	[idSede] [nchar](10) NOT NULL,
 CONSTRAINT [PK_ReservasXSede] PRIMARY KEY CLUSTERED 
(
	[numeroReserva] ASC,
	[idSede] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservaVisita]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservaVisita](
	[cantidadAlumno] [nchar](10) NULL,
	[cantidadAlumnoConfirmada] [nchar](10) NULL,
	[duracionEstimada] [nchar](10) NULL,
	[fechaHoraCreacion] [nchar](10) NULL,
	[fechaHoraReserva] [nchar](10) NULL,
	[horaFinReal] [nchar](10) NULL,
	[horaInicioReal] [nchar](10) NULL,
	[idReserva] [nchar](10) NOT NULL,
	[idSede] [nchar](10) NOT NULL,
	[idEscuela] [nchar](10) NULL,
 CONSTRAINT [PK_ReservaVisita] PRIMARY KEY CLUSTERED 
(
	[idReserva] ASC,
	[idSede] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sede]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sede](
	[idSede] [nchar](10) NOT NULL,
	[cantMaxPorGuia] [nchar](10) NULL,
	[nombre] [nchar](10) NULL,
	[cantMaximaVisitantes] [nchar](10) NULL,
 CONSTRAINT [PK_Sede] PRIMARY KEY CLUSTERED 
(
	[idSede] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sesion]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sesion](
	[fechaYHoraFin] [nchar](10) NULL,
	[nombreUsuario] [nchar](10) NOT NULL,
	[fechaYHoraInicio] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Sesion] PRIMARY KEY CLUSTERED 
(
	[nombreUsuario] ASC,
	[fechaYHoraInicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sexos]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sexos](
	[idSexo] [nchar](10) NOT NULL,
	[nombre] [nchar](10) NULL,
 CONSTRAINT [PK_Sexos] PRIMARY KEY CLUSTERED 
(
	[idSexo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoExposicion]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoExposicion](
	[idTipoExposicion] [nchar](10) NOT NULL,
	[nombreTipoExposicion] [nchar](10) NULL,
 CONSTRAINT [PK_TipoExposicion] PRIMARY KEY CLUSTERED 
(
	[idTipoExposicion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoVisita]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoVisita](
	[nombre] [nchar](10) NULL,
	[idTipoVisita] [nchar](10) NOT NULL,
 CONSTRAINT [PK_TipoVisita] PRIMARY KEY CLUSTERED 
(
	[idTipoVisita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[caducidad] [nchar](10) NULL,
	[contraseña] [nchar](10) NULL,
	[nombre] [nchar](10) NULL,
	[idUsuario] [nchar](10) NOT NULL,
	[cuitEmpleado] [nchar](10) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Valuaciones]    Script Date: 31/10/2022 17:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Valuaciones](
	[idValuacion] [nchar](10) NOT NULL,
	[nombre] [nchar](10) NULL,
 CONSTRAINT [PK_Valuaciones] PRIMARY KEY CLUSTERED 
(
	[idValuacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [DSI] SET  READ_WRITE 
GO

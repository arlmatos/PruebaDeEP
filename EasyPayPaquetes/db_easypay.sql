USE [master]
GO
/****** Object:  Database [easypay_paquetes]    Script Date: 6/3/2020 6:58:08 p. m. ******/
CREATE DATABASE [easypay_paquetes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'easypay_paquetes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\easypay_paquetes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'easypay_paquetes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\easypay_paquetes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [easypay_paquetes] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [easypay_paquetes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [easypay_paquetes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [easypay_paquetes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [easypay_paquetes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [easypay_paquetes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [easypay_paquetes] SET ARITHABORT OFF 
GO
ALTER DATABASE [easypay_paquetes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [easypay_paquetes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [easypay_paquetes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [easypay_paquetes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [easypay_paquetes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [easypay_paquetes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [easypay_paquetes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [easypay_paquetes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [easypay_paquetes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [easypay_paquetes] SET  ENABLE_BROKER 
GO
ALTER DATABASE [easypay_paquetes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [easypay_paquetes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [easypay_paquetes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [easypay_paquetes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [easypay_paquetes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [easypay_paquetes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [easypay_paquetes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [easypay_paquetes] SET RECOVERY FULL 
GO
ALTER DATABASE [easypay_paquetes] SET  MULTI_USER 
GO
ALTER DATABASE [easypay_paquetes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [easypay_paquetes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [easypay_paquetes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [easypay_paquetes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [easypay_paquetes] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'easypay_paquetes', N'ON'
GO
ALTER DATABASE [easypay_paquetes] SET QUERY_STORE = OFF
GO
USE [easypay_paquetes]
GO
/****** Object:  Table [dbo].[inventario_paquetes]    Script Date: 6/3/2020 6:58:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inventario_paquetes](
	[id_paquete] [int] IDENTITY(1,1) NOT NULL,
	[cod_paquete] [varchar](200) NOT NULL,
	[ubicacion] [varchar](200) NOT NULL,
	[origen] [varchar](100) NOT NULL,
	[fecha_envio] [datetime] NOT NULL,
	[remitente] [varchar](200) NOT NULL,
	[destinatario] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_paquete] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[cod_paquete] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ordenes]    Script Date: 6/3/2020 6:58:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ordenes](
	[id_orden] [int] IDENTITY(1,1) NOT NULL,
	[cod_paquete_orden] [varchar](200) NOT NULL,
	[fecha_hora_orden] [datetime] NOT NULL,
	[turno_orden] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[cod_paquete_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ordenes] ADD  DEFAULT ((1)) FOR [turno_orden]
GO
ALTER TABLE [dbo].[ordenes]  WITH CHECK ADD FOREIGN KEY([cod_paquete_orden])
REFERENCES [dbo].[inventario_paquetes] ([cod_paquete])
GO
USE [master]
GO
ALTER DATABASE [easypay_paquetes] SET  READ_WRITE 
GO

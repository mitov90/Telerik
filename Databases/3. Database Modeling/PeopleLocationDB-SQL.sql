USE [master]
GO
/****** Object:  Database [PeopleLocationDB]    Script Date: 8/21/2014 3:45:55 PM ******/
CREATE DATABASE [PeopleLocationDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PersonDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PersonDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PersonDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PersonDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PeopleLocationDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PeopleLocationDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PeopleLocationDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PeopleLocationDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PeopleLocationDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PeopleLocationDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PeopleLocationDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET RECOVERY FULL 
GO
ALTER DATABASE [PeopleLocationDB] SET  MULTI_USER 
GO
ALTER DATABASE [PeopleLocationDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PeopleLocationDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PeopleLocationDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PeopleLocationDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PeopleLocationDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PeopleLocationDB', N'ON'
GO
USE [PeopleLocationDB]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 8/21/2014 3:45:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressID] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Addresses_AddressID]  DEFAULT (newid()),
	[AddressText] [nvarchar](250) NULL,
	[TownID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 8/21/2014 3:45:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentID] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Continents_ContinentID]  DEFAULT (newid()),
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContinentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 8/21/2014 3:45:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Countries_CountryID]  DEFAULT (newid()),
	[Name] [nvarchar](50) NULL,
	[ContinentID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 8/21/2014 3:45:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonID] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Persons_PersonID]  DEFAULT (newid()),
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[AddressID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 8/21/2014 3:45:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TownID] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Towns_TownID]  DEFAULT (newid()),
	[Name] [nvarchar](50) NULL,
	[CountryID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownID])
REFERENCES [dbo].[Towns] ([TownID])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentID])
REFERENCES [dbo].[Continents] ([ContinentID])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Addresses] FOREIGN KEY([AddressID])
REFERENCES [dbo].[Addresses] ([AddressID])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [PeopleLocationDB] SET  READ_WRITE 
GO

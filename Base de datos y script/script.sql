USE [master]
GO
/****** Object:  Database [PasswordManagerDB]    Script Date: 17/06/2021 17:13:11 ******/
CREATE DATABASE [PasswordManagerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PasswordManagerDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PasswordManagerDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PasswordManagerDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PasswordManagerDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PasswordManagerDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PasswordManagerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PasswordManagerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PasswordManagerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PasswordManagerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PasswordManagerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PasswordManagerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PasswordManagerDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PasswordManagerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PasswordManagerDB] SET  MULTI_USER 
GO
ALTER DATABASE [PasswordManagerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PasswordManagerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PasswordManagerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PasswordManagerDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PasswordManagerDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PasswordManagerDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PasswordManagerDB] SET QUERY_STORE = OFF
GO
USE [PasswordManagerDB]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 17/06/2021 17:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryEntities]    Script Date: 17/06/2021 17:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ProfileEntity_Id] [int] NULL,
 CONSTRAINT [PK_dbo.CategoryEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditCardEntities]    Script Date: 17/06/2021 17:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCardEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [bigint] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[CCVCode] [smallint] NOT NULL,
	[ExpiryDate] [datetime] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[CategoryEntity_Id] [int] NULL,
	[Profile_Id] [int] NULL,
 CONSTRAINT [PK_dbo.CreditCardEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataBreachEntities]    Script Date: 17/06/2021 17:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataBreachEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Profile_Id] [int] NULL,
 CONSTRAINT [PK_dbo.DataBreachEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataBreachEntityCreditCardEntities]    Script Date: 17/06/2021 17:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataBreachEntityCreditCardEntities](
	[DataBreachEntity_Id] [int] NOT NULL,
	[CreditCardEntity_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.DataBreachEntityCreditCardEntities] PRIMARY KEY CLUSTERED 
(
	[DataBreachEntity_Id] ASC,
	[CreditCardEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PasswordEntities]    Script Date: 17/06/2021 17:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PasswordEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Site] [nvarchar](max) NULL,
	[User] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
	[Strength] [nvarchar](max) NULL,
	[LastModificationDate] [datetime] NOT NULL,
	[LastPasswordChange] [datetime] NOT NULL,
	[CategoryEntity_Id] [int] NULL,
	[Profile_Id] [int] NULL,
 CONSTRAINT [PK_dbo.PasswordEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PasswordEntityDataBreachEntities]    Script Date: 17/06/2021 17:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PasswordEntityDataBreachEntities](
	[PasswordEntity_Id] [int] NOT NULL,
	[DataBreachEntity_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PasswordEntityDataBreachEntities] PRIMARY KEY CLUSTERED 
(
	[PasswordEntity_Id] ASC,
	[DataBreachEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileEntities]    Script Date: 17/06/2021 17:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ProfileEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_ProfileEntity_Id]    Script Date: 17/06/2021 17:13:11 ******/
CREATE NONCLUSTERED INDEX [IX_ProfileEntity_Id] ON [dbo].[CategoryEntities]
(
	[ProfileEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryEntity_Id]    Script Date: 17/06/2021 17:13:11 ******/
CREATE NONCLUSTERED INDEX [IX_CategoryEntity_Id] ON [dbo].[CreditCardEntities]
(
	[CategoryEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Profile_Id]    Script Date: 17/06/2021 17:13:11 ******/
CREATE NONCLUSTERED INDEX [IX_Profile_Id] ON [dbo].[CreditCardEntities]
(
	[Profile_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Profile_Id]    Script Date: 17/06/2021 17:13:11 ******/
CREATE NONCLUSTERED INDEX [IX_Profile_Id] ON [dbo].[DataBreachEntities]
(
	[Profile_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CreditCardEntity_Id]    Script Date: 17/06/2021 17:13:11 ******/
CREATE NONCLUSTERED INDEX [IX_CreditCardEntity_Id] ON [dbo].[DataBreachEntityCreditCardEntities]
(
	[CreditCardEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DataBreachEntity_Id]    Script Date: 17/06/2021 17:13:11 ******/
CREATE NONCLUSTERED INDEX [IX_DataBreachEntity_Id] ON [dbo].[DataBreachEntityCreditCardEntities]
(
	[DataBreachEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryEntity_Id]    Script Date: 17/06/2021 17:13:11 ******/
CREATE NONCLUSTERED INDEX [IX_CategoryEntity_Id] ON [dbo].[PasswordEntities]
(
	[CategoryEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Profile_Id]    Script Date: 17/06/2021 17:13:11 ******/
CREATE NONCLUSTERED INDEX [IX_Profile_Id] ON [dbo].[PasswordEntities]
(
	[Profile_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DataBreachEntity_Id]    Script Date: 17/06/2021 17:13:11 ******/
CREATE NONCLUSTERED INDEX [IX_DataBreachEntity_Id] ON [dbo].[PasswordEntityDataBreachEntities]
(
	[DataBreachEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PasswordEntity_Id]    Script Date: 17/06/2021 17:13:11 ******/
CREATE NONCLUSTERED INDEX [IX_PasswordEntity_Id] ON [dbo].[PasswordEntityDataBreachEntities]
(
	[PasswordEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CategoryEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CategoryEntities_dbo.ProfileEntities_ProfileEntity_Id] FOREIGN KEY([ProfileEntity_Id])
REFERENCES [dbo].[ProfileEntities] ([Id])
GO
ALTER TABLE [dbo].[CategoryEntities] CHECK CONSTRAINT [FK_dbo.CategoryEntities_dbo.ProfileEntities_ProfileEntity_Id]
GO
ALTER TABLE [dbo].[CreditCardEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditCardEntities_dbo.CategoryEntities_CategoryEntity_Id] FOREIGN KEY([CategoryEntity_Id])
REFERENCES [dbo].[CategoryEntities] ([Id])
GO
ALTER TABLE [dbo].[CreditCardEntities] CHECK CONSTRAINT [FK_dbo.CreditCardEntities_dbo.CategoryEntities_CategoryEntity_Id]
GO
ALTER TABLE [dbo].[CreditCardEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditCardEntities_dbo.ProfileEntities_Profile_Id] FOREIGN KEY([Profile_Id])
REFERENCES [dbo].[ProfileEntities] ([Id])
GO
ALTER TABLE [dbo].[CreditCardEntities] CHECK CONSTRAINT [FK_dbo.CreditCardEntities_dbo.ProfileEntities_Profile_Id]
GO
ALTER TABLE [dbo].[DataBreachEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DataBreachEntities_dbo.ProfileEntities_Profile_Id] FOREIGN KEY([Profile_Id])
REFERENCES [dbo].[ProfileEntities] ([Id])
GO
ALTER TABLE [dbo].[DataBreachEntities] CHECK CONSTRAINT [FK_dbo.DataBreachEntities_dbo.ProfileEntities_Profile_Id]
GO
ALTER TABLE [dbo].[DataBreachEntityCreditCardEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DataBreachEntityCreditCardEntities_dbo.CreditCardEntities_CreditCardEntity_Id] FOREIGN KEY([CreditCardEntity_Id])
REFERENCES [dbo].[CreditCardEntities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DataBreachEntityCreditCardEntities] CHECK CONSTRAINT [FK_dbo.DataBreachEntityCreditCardEntities_dbo.CreditCardEntities_CreditCardEntity_Id]
GO
ALTER TABLE [dbo].[DataBreachEntityCreditCardEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DataBreachEntityCreditCardEntities_dbo.DataBreachEntities_DataBreachEntity_Id] FOREIGN KEY([DataBreachEntity_Id])
REFERENCES [dbo].[DataBreachEntities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DataBreachEntityCreditCardEntities] CHECK CONSTRAINT [FK_dbo.DataBreachEntityCreditCardEntities_dbo.DataBreachEntities_DataBreachEntity_Id]
GO
ALTER TABLE [dbo].[PasswordEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PasswordEntities_dbo.CategoryEntities_CategoryEntity_Id] FOREIGN KEY([CategoryEntity_Id])
REFERENCES [dbo].[CategoryEntities] ([Id])
GO
ALTER TABLE [dbo].[PasswordEntities] CHECK CONSTRAINT [FK_dbo.PasswordEntities_dbo.CategoryEntities_CategoryEntity_Id]
GO
ALTER TABLE [dbo].[PasswordEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PasswordEntities_dbo.ProfileEntities_Profile_Id] FOREIGN KEY([Profile_Id])
REFERENCES [dbo].[ProfileEntities] ([Id])
GO
ALTER TABLE [dbo].[PasswordEntities] CHECK CONSTRAINT [FK_dbo.PasswordEntities_dbo.ProfileEntities_Profile_Id]
GO
ALTER TABLE [dbo].[PasswordEntityDataBreachEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PasswordEntityDataBreachEntities_dbo.DataBreachEntities_DataBreachEntity_Id] FOREIGN KEY([DataBreachEntity_Id])
REFERENCES [dbo].[DataBreachEntities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PasswordEntityDataBreachEntities] CHECK CONSTRAINT [FK_dbo.PasswordEntityDataBreachEntities_dbo.DataBreachEntities_DataBreachEntity_Id]
GO
ALTER TABLE [dbo].[PasswordEntityDataBreachEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PasswordEntityDataBreachEntities_dbo.PasswordEntities_PasswordEntity_Id] FOREIGN KEY([PasswordEntity_Id])
REFERENCES [dbo].[PasswordEntities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PasswordEntityDataBreachEntities] CHECK CONSTRAINT [FK_dbo.PasswordEntityDataBreachEntities_dbo.PasswordEntities_PasswordEntity_Id]
GO
USE [master]
GO
ALTER DATABASE [PasswordManagerDB] SET  READ_WRITE 
GO

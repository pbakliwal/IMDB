USE [master]
GO
/****** Object:  Database [imdb]    Script Date: 29-11-2021 23:21:35 ******/
CREATE DATABASE [imdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'imdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\imdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'imdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\imdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [imdb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [imdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [imdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [imdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [imdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [imdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [imdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [imdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [imdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [imdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [imdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [imdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [imdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [imdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [imdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [imdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [imdb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [imdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [imdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [imdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [imdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [imdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [imdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [imdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [imdb] SET RECOVERY FULL 
GO
ALTER DATABASE [imdb] SET  MULTI_USER 
GO
ALTER DATABASE [imdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [imdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [imdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [imdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [imdb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [imdb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'imdb', N'ON'
GO
ALTER DATABASE [imdb] SET QUERY_STORE = OFF
GO
USE [imdb]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 29-11-2021 23:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Bio] [nvarchar](500) NULL,
	[DOB] [nvarchar](10) NULL,
	[Gender] [varchar](20) NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 29-11-2021 23:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[DOR] [nvarchar](10) NULL,
	[ProducerID] [int] NULL,
	[PosterURL] [nvarchar](255) NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieActorList]    Script Date: 29-11-2021 23:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieActorList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MovieID] [int] NULL,
	[ActorID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producer]    Script Date: 29-11-2021 23:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[CompanyName] [nvarchar](255) NULL,
	[Bio] [nvarchar](500) NULL,
	[DOB] [nvarchar](10) NULL,
	[Gender] [varchar](20) NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MovieActorList]  WITH CHECK ADD  CONSTRAINT [Fk_Actor] FOREIGN KEY([ActorID])
REFERENCES [dbo].[Actor] ([ID])
GO
ALTER TABLE [dbo].[MovieActorList] CHECK CONSTRAINT [Fk_Actor]
GO
ALTER TABLE [dbo].[MovieActorList]  WITH CHECK ADD  CONSTRAINT [Fk_Movie] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movie] ([ID])
GO
ALTER TABLE [dbo].[MovieActorList] CHECK CONSTRAINT [Fk_Movie]
GO
/****** Object:  StoredProcedure [dbo].[Sp_DeleteMovieList]    Script Date: 29-11-2021 23:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_DeleteMovieList]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from MovieActorList where MovieID = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteObjectByID]    Script Date: 29-11-2021 23:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteObjectByID]
	-- Add the parameters for the stored procedure here
	@TableName varchar(100),
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @TabName varchar(100);
	Declare @Sql nvarchar(MAX);
	Set @TabName = @TableName
    set @Sql = 	'Update ' + @TabName+ ' set IsDeleted = '+CONVERT(varchar, 1)+' where ID='+CONVERT(varchar,@ID);
    -- Insert statements for procedure here
	Exec sp_executesql @Sql;
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllData]    Script Date: 29-11-2021 23:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllData] 
	-- Add the parameters for the stored procedure here
	@TableName varchar(100)
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;
	Declare @TabName varchar(100);
	Declare @Sql nvarchar(MAX);
	set @TabName = @TableName
	set @Sql = 'Select * from ' + @TabName;
    -- Insert statements for procedure here
	Exec sp_executesql @Sql;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetObjectByParam]    Script Date: 29-11-2021 23:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetObjectByParam]
	-- Add the parameters for the stored procedure here
	@TableName varchar(100),
	@SearchCol nvarchar(500),
	@SearchValue nvarchar(500)
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;
	Declare @TabName varchar(100);
	Declare @Val nvarchar(255);
	Declare @Sql nvarchar(MAX);
	set @TabName = @TableName;
	set @Sql = 	'SELECT * from ' + @TableName+ ' where ' + @SearchCol+' = '''+@SearchValue+'''';
    -- Insert statements for procedure here
	Exec sp_executesql @Sql;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_InsertObjectActor]    Script Date: 29-11-2021 23:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_InsertObjectActor] 
	-- Add the parameters for the stored procedure here
	@ID int,
	@Name nvarchar(255),
	@Bio nvarchar(500) = '',
	@DOB datetime,
	@Gender varchar(20),
	@IsDeleted bit = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	Insert into Actor (Name,Bio,DOB,Gender,IsDeleted) values (@Name,@Bio,@DOB,@Gender,@IsDeleted);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertObjectProducer]    Script Date: 29-11-2021 23:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertObjectProducer] 
	-- Add the parameters for the stored procedure here
	@ID int,
	@Name nvarchar(255),
	@CompanyName nvarchar(255),
	@Bio nvarchar(500),
	@DOB nvarchar(10),
	@Gender varchar(20),
	@IsDeleted bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	Insert into Producer(Name,Bio,DOB,Gender,CompanyName,IsDeleted) values (@Name,@Bio,@DOB,@Gender,@CompanyName,@IsDeleted);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateObjectActor]    Script Date: 29-11-2021 23:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateObjectActor] 
	-- Add the parameters for the stored procedure here
	@ID int,
	@Name nvarchar(255),
	@Bio nvarchar(500),
	@DOB nvarchar(10),
	@Gender varchar(20),
	@IsDeleted bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	Update Actor set Name = @Name, Bio = @Bio, DOB = @DOB, Gender = @Gender, IsDeleted=@IsDeleted where ID = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateObjectProducer]    Script Date: 29-11-2021 23:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateObjectProducer] 
	-- Add the parameters for the stored procedure here
	@ID int,
	@Name nvarchar(255),
	@CompanyName nvarchar(255),
	@Bio nvarchar(500),
	@DOB nvarchar(10),
	@Gender varchar(20),
	@IsDeleted bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	Update Producer set Name = @Name, Bio = @Bio, DOB = @DOB, Gender = @Gender, IsDeleted=@IsDeleted,CompanyName=@CompanyName where ID = @ID;
END
GO
USE [master]
GO
ALTER DATABASE [imdb] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [UsersDB]    Script Date: 24.02.2020 11:02:30 ******/
CREATE DATABASE [UsersDB] ON  PRIMARY 
( NAME = N'UsersDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\UsersDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UsersDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\UsersDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UsersDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UsersDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UsersDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UsersDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UsersDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UsersDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UsersDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UsersDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UsersDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UsersDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UsersDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UsersDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UsersDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UsersDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UsersDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UsersDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UsersDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UsersDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UsersDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UsersDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UsersDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UsersDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UsersDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UsersDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UsersDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UsersDB] SET  MULTI_USER 
GO
ALTER DATABASE [UsersDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UsersDB] SET DB_CHAINING OFF 
GO
USE [UsersDB]
GO
/****** Object:  Table [dbo].[Awards]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Awards](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[AwardImage] [image] NOT NULL,
 CONSTRAINT [PK_Awards] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClientRoles]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientRoles](
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](6) NOT NULL,
 CONSTRAINT [PK_ClientRoles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Clients]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](50) NOT NULL,
	[ClientPassword] [nvarchar](50) NOT NULL,
	[ClientRole] [int] NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ClientName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Awards]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Awards](
	[UserID] [int] NOT NULL,
	[AwardID] [int] NOT NULL,
 CONSTRAINT [PK_User_Awards] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[AwardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[UserImage] [image] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

INSERT [dbo].[ClientRoles] ([RoleID], [RoleName]) VALUES (0, N'User')
INSERT [dbo].[ClientRoles] ([RoleID], [RoleName]) VALUES (1, N'Admin')
SET IDENTITY_INSERT [dbo].[Clients] ON 
INSERT [dbo].[Clients] ([ClientID], [ClientName], [ClientPassword], [ClientRole]) VALUES (1, N'FlamingEye', N'password', 1)
SET IDENTITY_INSERT [dbo].[Clients] OFF

GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_ClientRoles] FOREIGN KEY([ClientRole])
REFERENCES [dbo].[ClientRoles] ([RoleID])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_ClientRoles]
GO
ALTER TABLE [dbo].[User_Awards]  WITH CHECK ADD  CONSTRAINT [FK_User_Awards_Awards] FOREIGN KEY([AwardID])
REFERENCES [dbo].[Awards] ([ID])
GO
ALTER TABLE [dbo].[User_Awards] CHECK CONSTRAINT [FK_User_Awards_Awards]
GO
ALTER TABLE [dbo].[User_Awards]  WITH CHECK ADD  CONSTRAINT [FK_User_Awards_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[User_Awards] CHECK CONSTRAINT [FK_User_Awards_Users]
GO
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAward] 
	@title nvarchar(50),
	@award_image image,
	@id int output
AS
BEGIN
	INSERT INTO Awards (Title, AwardImage)
	VALUES (@title, @award_image)
	set @id = SCOPE_IDENTITY() 
END

GO
/****** Object:  StoredProcedure [dbo].[AddAwardToUser]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAwardToUser] 
	@user_id int,
	@award_id int
AS
BEGIN
	INSERT INTO User_Awards (UserID, AwardID)
	VALUES (@user_id, @award_id)
END

GO
/****** Object:  StoredProcedure [dbo].[AddClient]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddClient]
	@user_name nvarchar(50),
	@user_pass nvarchar(50)
AS
BEGIN
	INSERT INTO Clients(ClientName, ClientPassword, ClientRole)
	VALUES (@user_name, @user_pass, 0)
END

GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser]
	@name nvarchar(50),
	@date_of_birth datetime,
	@user_image image,
	@id int output
AS
BEGIN
	INSERT INTO Users (Name, DateOfBirth, UserImage)
	Values(@name, @date_of_birth, @user_image)
	set @id = SCOPE_IDENTITY();
END

GO
/****** Object:  StoredProcedure [dbo].[CheckAuth]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CheckAuth] 
	@user_name nvarchar(50),
	@user_pass nvarchar(50)
AS
BEGIN
	SELECT ClientID
	FROM Clients
	WHERE ClientName = @user_name AND ClientPassword = @user_pass
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllAwards]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllAwards]
	
AS
BEGIN
	SELECT ID, Title, AwardImage 
	FROM Awards
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllClients]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllClients] 
	
AS
BEGIN
	SELECT ClientID, ClientName, RoleName 
	FROM Clients, ClientRoles
	WHERE ClientRole = RoleID
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
	SELECT ID, Name, DateOfBirth, UserImage 
	FROM Users
END

GO
/****** Object:  StoredProcedure [dbo].[GetAwardById]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardById]
	@id int
AS
BEGIN
	SELECT ID, Title, AwardImage 
	FROM Awards
	WHERE ID = @id
END

GO
/****** Object:  StoredProcedure [dbo].[GetAwardByTitle]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardByTitle]
	@title nvarchar(50)
AS
BEGIN
	SELECT ID, Title, AwardImage 
	FROM Awards
	WHERE Title = @title
END

GO
/****** Object:  StoredProcedure [dbo].[GetClientRoles]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetClientRoles] 
	@user_id int
AS
BEGIN
	SELECT ClientRoles.RoleName
	FROM Clients, ClientRoles
	WHERE Clients.ClientID = @user_id AND ClientRoles.RoleID <= Clients.ClientRole
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserAwards]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserAwards]
	@id int
AS
BEGIN
	SELECT Awards.ID, Awards.Title, Awards.AwardImage 
	FROM User_Awards, Awards
	WHERE User_Awards.UserID = @id AND User_Awards.AwardID = Awards.ID
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserById]
	@id int
AS
BEGIN
	SELECT ID, Name, DateOfBirth, UserImage 
	FROM Users
	WHERE ID = @id
END

GO
/****** Object:  StoredProcedure [dbo].[GetUsersCount]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUsersCount] 
AS
BEGIN
	SELECT COUNT(*) FROM Users
END

GO
/****** Object:  StoredProcedure [dbo].[HasClient]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[HasClient] 
	@user_name nvarchar(50)
AS
BEGIN
	SELECT ClientID
	FROM Clients
	WHERE Clients.ClientName = @user_name
END

GO
/****** Object:  StoredProcedure [dbo].[MakeClientAdmin]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MakeClientAdmin]
	@user_id int
AS
BEGIN
	UPDATE Clients
	SET ClientRole = 1
	WHERE ClientID = @user_id
END

GO
/****** Object:  StoredProcedure [dbo].[MakeClientUser]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MakeClientUser]
	@user_id int
AS
BEGIN
	UPDATE Clients
	SET ClientRole = 0
	WHERE ClientID = @user_id
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveAllAwardsFromUser]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveAllAwardsFromUser] 
	@id int
AS
BEGIN
	DELETE FROM User_Awards
	WHERE User_Awards.UserID = @id
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveAward]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveAward]
	@id int
AS
BEGIN
	DELETE FROM Awards
	WHERE ID = @id
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveAwardFromAll]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveAwardFromAll]
	@award_id int
AS
BEGIN
	DELETE FROM User_Awards
	WHERE AwardID = @award_id
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveAwardFromUser]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveAwardFromUser] 
	@user_id int,
	@award_id int
AS
BEGIN
	DELETE FROM User_Awards
	WHERE UserID = @user_id AND AwardID = @award_id
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveUser]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveUser] 
	@id int
AS
BEGIN
	DELETE FROM Users
	WHERE ID = @id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateAward]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAward]
	@id int,
	@title nvarchar(50),
	@award_image image
AS
BEGIN
	UPDATE Awards
	SET Title = @title, AwardImage = @award_image
	WHERE ID = @id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 24.02.2020 11:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser] 
	@id int,
	@name nvarchar(50),
	@date_of_birth datetime,
	@user_image image
AS
BEGIN
	UPDATE Users 
	SET Name = @name, DateOfBirth = @date_of_birth, UserImage = @user_image
	WHERE ID = @id
END

GO
USE [master]
GO
ALTER DATABASE [UsersDB] SET  READ_WRITE 
GO

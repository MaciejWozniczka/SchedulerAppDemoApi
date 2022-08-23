USE [master]
GO
DECLARE @sql NVARCHAR(MAX) = N'';
SELECT @sql += N'
DROP DATABASE ' + QUOTENAME(name)
+ N';'
FROM sys.databases
WHERE name NOT IN (N'master',N'tempdb',N'model',N'msdb')
ORDER BY source_database_id desc;



EXEC master.sys.sp_executesql @sql;
GO
/****** Object:  Database [SchedulerApp]    Script Date: 23.08.2022 18:58:13 ******/
CREATE DATABASE [SchedulerApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SchedulerApp', FILENAME = N'/var/opt/mssql/data/SchedulerApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SchedulerApp_log', FILENAME = N'/var/opt/mssql/data/SchedulerApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SchedulerApp] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SchedulerApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SchedulerApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SchedulerApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SchedulerApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SchedulerApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SchedulerApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [SchedulerApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SchedulerApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SchedulerApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SchedulerApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SchedulerApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SchedulerApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SchedulerApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SchedulerApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SchedulerApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SchedulerApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SchedulerApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SchedulerApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SchedulerApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SchedulerApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SchedulerApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SchedulerApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SchedulerApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SchedulerApp] SET RECOVERY FULL 
GO
ALTER DATABASE [SchedulerApp] SET  MULTI_USER 
GO
ALTER DATABASE [SchedulerApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SchedulerApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SchedulerApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SchedulerApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SchedulerApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SchedulerApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SchedulerApp', N'ON'
GO
ALTER DATABASE [SchedulerApp] SET QUERY_STORE = OFF
GO
USE [SchedulerApp]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23.08.2022 18:58:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 23.08.2022 18:58:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 23.08.2022 18:58:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 23.08.2022 18:58:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 23.08.2022 18:58:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 23.08.2022 18:58:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [nvarchar](max) NULL,
	[RoleId] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23.08.2022 18:58:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 23.08.2022 18:58:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[UserId] [nvarchar](max) NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220823162755_Database', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220823162831_AddBaseUserSettings', N'6.0.8')
GO
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'23fae70a-8a08-4b93-9173-8ce66a329709', N'clientadmin', N'CLIENTADMIN', N'ec478b73-0bd7-4a79-a003-eab5ffd3dd88')
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'45b29d8e-a5f5-4041-9821-4ecbcf64aa18', N'admin', N'ADMIN', N'eaec138b-6d3e-4731-8f2b-180531da429b')
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'cb24aebf-935e-49e9-a268-5427c6889b16', N'clientuser', N'CLIENTUSER', N'7103347c-bbd8-4907-8286-466789550c9a')
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'4c289587-ba9f-40d8-b7e7-d62801358fd8', N'45b29d8e-a5f5-4041-9821-4ecbcf64aa18')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'4c289587-ba9f-40d8-b7e7-d62801358fd8', N'23fae70a-8a08-4b93-9173-8ce66a329709')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'4c289587-ba9f-40d8-b7e7-d62801358fd8', N'cb24aebf-935e-49e9-a268-5427c6889b16')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'ab746421-ccd2-4994-89c0-a61bf4e4c305', N'23fae70a-8a08-4b93-9173-8ce66a329709')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'becf732d-9b33-481c-9c14-e60df1342be7', N'cb24aebf-935e-49e9-a268-5427c6889b16')
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4c289587-ba9f-40d8-b7e7-d62801358fd8', N'Admin', N'ADMIN', N'maciej.wozniczka@outlook.com', N'MACIEJ.WOZNICZKA@OUTLOOK.COM', 0, N'AQAAAAEAACcQAAAAEGF0vqv9zdrQg3x5R/NjqKMTQjL2qVHHilVGsW3P6oJexM8ArasgRNdwasik0b9oHg==', N'SWSUNKRE64TQAQL3TPRXD3UNJYRTKCCX', N'c8706780-216f-4e31-82a3-6ea012937c22', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ab746421-ccd2-4994-89c0-a61bf4e4c305', N'ClientAdmin', N'CLIENTADMIN', N'maciej.wozniczka2@outlook.com', N'MACIEJ.WOZNICZKA2@OUTLOOK.COM', 0, N'AQAAAAEAACcQAAAAEHbBc87Q49u1Us5Z7myzelZX9PdEy2kj6XeG85UiT35CgDytzVXHYlqzs93OfR+NEg==', N'KGLLOJBKE42ZTDH5CTB5LF746GJS6F2O', N'7347eca9-d6f7-4220-9f8b-260765820205', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'becf732d-9b33-481c-9c14-e60df1342be7', N'ClientUser', N'CLIENTUSER', N'maciej.wozniczka3@outlook.com', N'MACIEJ.WOZNICZKA3@OUTLOOK.COM', 0, N'AQAAAAEAACcQAAAAEB0vYugMO8Tu03fSJSxpgWyLx3orGV/hTekjjcum4q6hXfyzUqJm9Oi4QAzc8wXN2w==', N'JQWUSMGMGEWLLAN34XCYYEAMJIVCSUOO', N'beeb70ba-805d-4790-89a1-a55ee548640b', NULL, 0, 0, NULL, 1, 0)
GO
USE [master]
GO
ALTER DATABASE [SchedulerApp] SET  READ_WRITE 
GO
CREATE DATABASE [SchedulerApp_Snapshot] ON
( NAME = [SchedulerApp], FILENAME = '/var/opt/mssql/snapshots/SchedulerApp_Snapshot.ss' )
AS SNAPSHOT OF [SchedulerApp];
GO

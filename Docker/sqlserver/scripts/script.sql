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

/****** Object:  Database [SchedulerApp]    Script Date: 23.08.2022 22:06:28 ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23.08.2022 22:06:28 ******/
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
/****** Object:  Table [dbo].[Companies]    Script Date: 23.08.2022 22:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompaniesOpeningHours]    Script Date: 23.08.2022 22:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompaniesOpeningHours](
	[Id] [uniqueidentifier] NOT NULL,
	[CompanyId] [uniqueidentifier] NOT NULL,
	[DayOfTheWeek] [int] NOT NULL,
	[OpeningTime] [datetime2](7) NOT NULL,
	[ClosingTime] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_CompaniesOpeningHours] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 23.08.2022 22:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CompanyId] [uniqueidentifier] NOT NULL,
	[MonthlyWorkingHours] [int] NOT NULL,
	[DailyWorkingHours] [int] NOT NULL,
	[MaxDailyWorkingHours] [int] NOT NULL,
	[PreferredTimeOfDay] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeesPositions]    Script Date: 23.08.2022 22:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesPositions](
	[Id] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[PositionId] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_EmployeesPositions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Licences]    Script Date: 23.08.2022 22:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Licences](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Licences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 23.08.2022 22:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 23.08.2022 22:06:28 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 23.08.2022 22:06:28 ******/
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
/****** Object:  Table [dbo].[UserClaims]    Script Date: 23.08.2022 22:06:28 ******/
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
/****** Object:  Table [dbo].[UserCompanies]    Script Date: 23.08.2022 22:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCompanies](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CompanyId] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserCompanies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLicences]    Script Date: 23.08.2022 22:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLicences](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[LicenceId] [uniqueidentifier] NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserLicences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 23.08.2022 22:06:28 ******/
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
/****** Object:  Table [dbo].[UserRoles]    Script Date: 23.08.2022 22:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [nvarchar](max) NULL,
	[RoleId] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23.08.2022 22:06:28 ******/
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
/****** Object:  Table [dbo].[UserTokens]    Script Date: 23.08.2022 22:06:28 ******/
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
/****** Object:  Table [dbo].[WorkdayRequirements]    Script Date: 23.08.2022 22:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkdayRequirements](
	[Id] [uniqueidentifier] NOT NULL,
	[CompanyId] [uniqueidentifier] NOT NULL,
	[PositionId] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[DayOfTheWeek] [int] NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[EndTime] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_WorkdayRequirements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220823162755_Database', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220823162831_AddBaseUserSettings', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220823200327_AddApplicationDbModel', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220823200504_FillInTestData', N'6.0.8')
GO
INSERT [dbo].[Companies] ([Id], [Name], [IsActive]) VALUES (N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'Deadline Maciej Wozniczka', 1)
GO
INSERT [dbo].[CompaniesOpeningHours] ([Id], [CompanyId], [DayOfTheWeek], [OpeningTime], [ClosingTime], [IsActive]) VALUES (N'7378f0a0-03da-4817-a592-132616daa8fd', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', 2, CAST(N'0001-01-01T06:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T22:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[CompaniesOpeningHours] ([Id], [CompanyId], [DayOfTheWeek], [OpeningTime], [ClosingTime], [IsActive]) VALUES (N'59f7e852-5dbb-47d1-a3fc-3eed093e20b3', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', 4, CAST(N'0001-01-01T06:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T22:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[CompaniesOpeningHours] ([Id], [CompanyId], [DayOfTheWeek], [OpeningTime], [ClosingTime], [IsActive]) VALUES (N'ed9d6db9-9801-4679-aaaf-4df2e8e69975', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', 1, CAST(N'0001-01-01T06:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T22:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[CompaniesOpeningHours] ([Id], [CompanyId], [DayOfTheWeek], [OpeningTime], [ClosingTime], [IsActive]) VALUES (N'a59f3f73-e376-45ac-a441-a637bedc6a08', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', 6, CAST(N'0001-01-01T06:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T22:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[CompaniesOpeningHours] ([Id], [CompanyId], [DayOfTheWeek], [OpeningTime], [ClosingTime], [IsActive]) VALUES (N'476986df-c81d-4dbc-a1a5-b672d7ea7ca6', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', 5, CAST(N'0001-01-01T06:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T22:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[CompaniesOpeningHours] ([Id], [CompanyId], [DayOfTheWeek], [OpeningTime], [ClosingTime], [IsActive]) VALUES (N'831bd1a4-fa1b-4dfa-8df7-d27871908e58', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', 3, CAST(N'0001-01-01T06:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T22:00:00.0000000' AS DateTime2), 1)
GO
INSERT [dbo].[Employees] ([Id], [Name], [CompanyId], [MonthlyWorkingHours], [DailyWorkingHours], [MaxDailyWorkingHours], [PreferredTimeOfDay], [IsActive]) VALUES (N'e7dcb104-eb2a-49b3-920d-51c80d6ea7bb', N'Pracownik6', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', 64, 8, 10, N'Full', 1)
INSERT [dbo].[Employees] ([Id], [Name], [CompanyId], [MonthlyWorkingHours], [DailyWorkingHours], [MaxDailyWorkingHours], [PreferredTimeOfDay], [IsActive]) VALUES (N'722a2f65-060a-41a8-b008-8199b8a4ec0b', N'Pracownik5', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', 64, 8, 10, N'Full', 1)
INSERT [dbo].[Employees] ([Id], [Name], [CompanyId], [MonthlyWorkingHours], [DailyWorkingHours], [MaxDailyWorkingHours], [PreferredTimeOfDay], [IsActive]) VALUES (N'2244e9c2-d651-4f30-a3ae-973ba8f3b52e', N'Pracownik3', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', 168, 8, 10, N'Full', 1)
INSERT [dbo].[Employees] ([Id], [Name], [CompanyId], [MonthlyWorkingHours], [DailyWorkingHours], [MaxDailyWorkingHours], [PreferredTimeOfDay], [IsActive]) VALUES (N'496ee0b8-1549-46c1-b999-a0f621117378', N'Pracownik4', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', 168, 8, 10, N'Full', 1)
INSERT [dbo].[Employees] ([Id], [Name], [CompanyId], [MonthlyWorkingHours], [DailyWorkingHours], [MaxDailyWorkingHours], [PreferredTimeOfDay], [IsActive]) VALUES (N'f1b5c9f2-f3f8-4b95-b437-a77285786735', N'Kierownik1', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', 168, 8, 10, N'Full', 1)
INSERT [dbo].[Employees] ([Id], [Name], [CompanyId], [MonthlyWorkingHours], [DailyWorkingHours], [MaxDailyWorkingHours], [PreferredTimeOfDay], [IsActive]) VALUES (N'4490cb06-dafc-4e65-bba4-b77170c1afb3', N'Pracownik2', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', 168, 8, 10, N'Full', 1)
INSERT [dbo].[Employees] ([Id], [Name], [CompanyId], [MonthlyWorkingHours], [DailyWorkingHours], [MaxDailyWorkingHours], [PreferredTimeOfDay], [IsActive]) VALUES (N'f9a08c71-f0cc-4bd6-8725-bca9fd2647f2', N'Pracownik1', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', 168, 8, 10, N'Full', 1)
INSERT [dbo].[Employees] ([Id], [Name], [CompanyId], [MonthlyWorkingHours], [DailyWorkingHours], [MaxDailyWorkingHours], [PreferredTimeOfDay], [IsActive]) VALUES (N'dead1b35-6b6f-4dc9-993a-d14511d927ef', N'Kierownik2', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', 84, 8, 10, N'Full', 1)
GO
INSERT [dbo].[EmployeesPositions] ([Id], [EmployeeId], [PositionId], [IsActive]) VALUES (N'87b85787-8bdd-4a96-9047-124ac77d35a2', N'496ee0b8-1549-46c1-b999-a0f621117378', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 1)
INSERT [dbo].[EmployeesPositions] ([Id], [EmployeeId], [PositionId], [IsActive]) VALUES (N'4d4f77bb-759a-4c91-9836-3500c61d05ce', N'dead1b35-6b6f-4dc9-993a-d14511d927ef', N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6', 1)
INSERT [dbo].[EmployeesPositions] ([Id], [EmployeeId], [PositionId], [IsActive]) VALUES (N'10edde30-cc29-4bb2-b86c-35706be8b176', N'f9a08c71-f0cc-4bd6-8725-bca9fd2647f2', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 1)
INSERT [dbo].[EmployeesPositions] ([Id], [EmployeeId], [PositionId], [IsActive]) VALUES (N'b00cf3e9-aa62-48e5-8bea-42321a08e496', N'722a2f65-060a-41a8-b008-8199b8a4ec0b', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 1)
INSERT [dbo].[EmployeesPositions] ([Id], [EmployeeId], [PositionId], [IsActive]) VALUES (N'99215613-d78b-4d38-a2aa-6c6b3c1ab892', N'e7dcb104-eb2a-49b3-920d-51c80d6ea7bb', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 1)
INSERT [dbo].[EmployeesPositions] ([Id], [EmployeeId], [PositionId], [IsActive]) VALUES (N'6b114686-d10e-4624-83f0-78e9b134c884', N'4490cb06-dafc-4e65-bba4-b77170c1afb3', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 1)
INSERT [dbo].[EmployeesPositions] ([Id], [EmployeeId], [PositionId], [IsActive]) VALUES (N'abae9ecd-35df-46e4-9746-a53b44f579ee', N'2244e9c2-d651-4f30-a3ae-973ba8f3b52e', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 1)
INSERT [dbo].[EmployeesPositions] ([Id], [EmployeeId], [PositionId], [IsActive]) VALUES (N'49d7e0f3-dfea-4eae-8f9d-fa67114b4992', N'f1b5c9f2-f3f8-4b95-b437-a77285786735', N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6', 1)
GO
INSERT [dbo].[Licences] ([Id], [Name], [IsActive]) VALUES (N'7e231a2e-9eda-4b6c-b32b-006ee267608b', N'LifeTime', 1)
INSERT [dbo].[Licences] ([Id], [Name], [IsActive]) VALUES (N'f0d0ae24-e00e-432f-a1e9-c7167dd8bed3', N'Free', 1)
INSERT [dbo].[Licences] ([Id], [Name], [IsActive]) VALUES (N'40b712a8-44d7-4352-8d3d-e9fd00836a66', N'Subscription', 1)
GO
INSERT [dbo].[Positions] ([Id], [Name], [IsActive]) VALUES (N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6', N'Kierownik', 1)
INSERT [dbo].[Positions] ([Id], [Name], [IsActive]) VALUES (N'9702d623-3b79-413a-a67d-7928c2e3e5ed', N'Pracownik', 1)
GO
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'23fae70a-8a08-4b93-9173-8ce66a329709', N'clientadmin', N'CLIENTADMIN', N'ec478b73-0bd7-4a79-a003-eab5ffd3dd88')
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'45b29d8e-a5f5-4041-9821-4ecbcf64aa18', N'admin', N'ADMIN', N'eaec138b-6d3e-4731-8f2b-180531da429b')
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'cb24aebf-935e-49e9-a268-5427c6889b16', N'clientuser', N'CLIENTUSER', N'7103347c-bbd8-4907-8286-466789550c9a')
GO
INSERT [dbo].[UserCompanies] ([Id], [UserId], [CompanyId], [IsActive]) VALUES (N'25b1db62-d43f-4943-b654-f277f3bcf99f', N'4c289587-ba9f-40d8-b7e7-d62801358fd8', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', 1)
GO
INSERT [dbo].[UserLicences] ([Id], [UserId], [LicenceId], [ValidFrom], [ValidTo], [IsActive]) VALUES (N'4876aaf3-36c2-46c7-9c55-092593b926dc', N'4c289587-ba9f-40d8-b7e7-d62801358fd8', N'7e231a2e-9eda-4b6c-b32b-006ee267608b', CAST(N'2000-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2999-12-31T00:00:00.0000000' AS DateTime2), 1)
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
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'92025414-8759-4a39-bb3d-01c84bffecf8', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 1, 2, CAST(N'0001-01-01T13:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T17:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'6055f617-47b4-4161-8a62-0cfbfe75cd78', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6', 1, 2, CAST(N'0001-01-01T10:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T20:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'a8722d8e-a727-48ce-9cde-15e65b7a0096', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6', 1, 1, CAST(N'0001-01-01T10:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T20:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'912b021d-1fd9-48e3-9623-1bf4331133ed', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 2, 6, CAST(N'0001-01-01T10:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T18:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'6b0e347e-2ed1-4dd1-9689-2a54519c29af', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 2, 5, CAST(N'0001-01-01T10:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T18:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'3f877c0b-3088-45fe-96f0-2d4e25c1d318', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 2, 6, CAST(N'0001-01-01T14:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T22:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'0c4a36ba-0261-4fec-ad0f-3d9a363e1555', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 2, 2, CAST(N'0001-01-01T14:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T22:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'e0e9ffd8-6621-4fc2-a2aa-5909740e3d4e', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 2, 5, CAST(N'0001-01-01T14:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T22:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'e15e94c1-cee2-461a-a561-60dac4f29eec', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 2, 6, CAST(N'0001-01-01T12:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T16:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'711811a6-f83b-4c63-8808-6afde598a5be', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 1, 4, CAST(N'0001-01-01T13:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T17:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'1e52f8d0-1972-4672-b5e4-6c07d03e486c', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6', 1, 5, CAST(N'0001-01-01T10:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T20:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'91e45c3c-a275-47fe-a203-7aa06a345849', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6', 1, 3, CAST(N'0001-01-01T10:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T20:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'ada1ff09-1f53-4b09-88bc-8098230c065d', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 1, 3, CAST(N'0001-01-01T13:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T17:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'77bc160f-8653-4ecf-b324-8325202739a7', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 2, 1, CAST(N'0001-01-01T06:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T14:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'24741c10-09e2-4b77-bc16-9050538e16d0', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 2, 4, CAST(N'0001-01-01T06:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T14:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'0a9c25e9-68c9-48db-9056-9eb59d82c66d', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 2, 1, CAST(N'0001-01-01T14:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T22:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'ae09cdc3-3cca-43bd-bb4a-9f305a7f999d', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 2, 4, CAST(N'0001-01-01T14:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T22:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'e5d43867-f579-4dbd-987c-c0d93453e158', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 2, 3, CAST(N'0001-01-01T14:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T22:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'1e07f138-7968-4c2d-a69b-c5b31243366c', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6', 1, 6, CAST(N'0001-01-01T10:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T20:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'fbd38163-e29f-42f6-a81e-c71c3d3f7579', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 2, 5, CAST(N'0001-01-01T12:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T16:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'082d461b-c09a-4e9d-8594-c829d930aef9', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 1, 1, CAST(N'0001-01-01T13:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T17:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'6b2ed51b-df15-4651-9fc4-ccc07eb48d05', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 2, 2, CAST(N'0001-01-01T06:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T14:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'd1ad81c7-95b8-40eb-aa3f-d683414215db', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 2, 5, CAST(N'0001-01-01T06:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T14:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'300f7173-828a-4c3e-80c3-d72f4c07dc04', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 2, 6, CAST(N'0001-01-01T06:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T14:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'4444a3b7-7156-489b-9c21-e0c3662cf893', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'd2ff4ffc-15e3-4db5-9a76-528ed84b9eb6', 1, 4, CAST(N'0001-01-01T10:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T20:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[WorkdayRequirements] ([Id], [CompanyId], [PositionId], [Quantity], [DayOfTheWeek], [StartTime], [EndTime], [IsActive]) VALUES (N'18a829b2-7048-419b-9d78-f91bd4b3f880', N'7f3f5ffa-bf1c-4c9b-98a6-2b1bd0bd7084', N'9702d623-3b79-413a-a67d-7928c2e3e5ed', 2, 3, CAST(N'0001-01-01T06:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T14:00:00.0000000' AS DateTime2), 1)
GO
USE [master]
GO
ALTER DATABASE [SchedulerApp] SET  READ_WRITE 
GO
CREATE DATABASE [SchedulerApp_Snapshot] ON
( NAME = [SchedulerApp], FILENAME = '/var/opt/mssql/snapshots/SchedulerApp_Snapshot.ss' )
AS SNAPSHOT OF [SchedulerApp];
GO

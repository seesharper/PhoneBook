USE [master]
GO
/****** Object:  Database [PhoneBook]    Script Date: 10.02.2013 22:14:16 ******/
CREATE DATABASE [PhoneBook] ON  PRIMARY 
( NAME = N'PhoneBook', FILENAME = N'D:\DB\SQLServer\2012\PhoneBook.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PhoneBook_log', FILENAME = N'D:\DB\SQLServer\2012\PhoneBook_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PhoneBook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PhoneBook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PhoneBook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PhoneBook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PhoneBook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PhoneBook] SET ARITHABORT OFF 
GO
ALTER DATABASE [PhoneBook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PhoneBook] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PhoneBook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PhoneBook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PhoneBook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PhoneBook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PhoneBook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PhoneBook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PhoneBook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PhoneBook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PhoneBook] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PhoneBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PhoneBook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PhoneBook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PhoneBook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PhoneBook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PhoneBook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PhoneBook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PhoneBook] SET RECOVERY FULL 
GO
ALTER DATABASE [PhoneBook] SET  MULTI_USER 
GO
ALTER DATABASE [PhoneBook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PhoneBook] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PhoneBook', N'ON'
GO
USE [PhoneBook]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 10.02.2013 22:14:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 10.02.2013 22:14:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BirthDay] [datetime] NOT NULL,
	[Notes] [nvarchar](400) NOT NULL,
	[RecordDate] [datetime] NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Phones]    Script Date: 10.02.2013 22:14:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phones](
	[PhoneId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Number] [nvarchar](20) NOT NULL,
	[RecordDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Phones] PRIMARY KEY CLUSTERED 
(
	[PhoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (1, N'Adana')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (2, N'Amsterdam')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (3, N'Ankara')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (4, N'Athens')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (5, N'Bandung')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (6, N'Bangalore')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (7, N'Bangkok')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (8, N'Barcelona')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (9, N'Beijing')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (10, N'Berlin')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (11, N'Buenos Aires')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (12, N'Cairo')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (13, N'Cape Town')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (14, N'Chicago')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (15, N'Córdoba')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (16, N'Curitiba')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (17, N'Delhi')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (18, N'Donetsk')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (19, N'Eindhoven')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (20, N'Florence')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (21, N'Frankfurt')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (22, N'Glasgow')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (23, N'Gothenburg')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (24, N'Guangzhou')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (25, N'Hai Phong')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (26, N'Hamburg')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (27, N'Hanoi')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (28, N'Houston')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (29, N'Hyderabad')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (30, N'İstanbul')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (31, N'İzmir')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (32, N'Jakarta')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (33, N'Kraków')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (34, N'Kunming')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (35, N'Kyiv')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (36, N'Lisbon')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (37, N'Liverpool')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (38, N'London')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (39, N'Los Angeles')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (40, N'Lyon')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (41, N'Madrid')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (42, N'Manchester')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (43, N'Melbourne')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (44, N'Mexico City')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (45, N'Milano')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (46, N'Montreal')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (47, N'Moscow')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (48, N'Mumbai')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (49, N'Munich')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (50, N'New York')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (51, N'Nice')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (52, N'Nonthaburi')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (53, N'Paris')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (54, N'Petersburg')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (55, N'Porto')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (56, N'Rio de Janeiro')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (57, N'Rome')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (58, N'Salvador')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (59, N'São Paulo')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (60, N'Semarang')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (61, N'Shanghai')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (62, N'Stockholm')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (63, N'Surabaya')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (64, N'Sydney')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (65, N'Tijuana')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (66, N'Torino')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (67, N'Toronto')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (68, N'Toulouse')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (69, N'Volos')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (70, N'Warsaw')
SET IDENTITY_INSERT [dbo].[Cities] OFF
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([PersonId], [CityId], [Name], [BirthDay], [Notes], [RecordDate]) VALUES (9, 50, N'Isaac Asimov', CAST(0x00001C8900000000 AS DateTime), N'SF!', CAST(0x0000A15A017FD810 AS DateTime))
INSERT [dbo].[People] ([PersonId], [CityId], [Name], [BirthDay], [Notes], [RecordDate]) VALUES (10, 38, N'Dauglas Adams', CAST(0x00004A6C00000000 AS DateTime), N'42 :)', CAST(0x0000A15A01804D40 AS DateTime))
INSERT [dbo].[People] ([PersonId], [CityId], [Name], [BirthDay], [Notes], [RecordDate]) VALUES (11, 1, N'İhsan Oktay Anar', CAST(0x0000559A00000000 AS DateTime), N'Puslu Kıtalar Atlası', CAST(0x0000A15A0180E6C4 AS DateTime))
INSERT [dbo].[People] ([PersonId], [CityId], [Name], [BirthDay], [Notes], [RecordDate]) VALUES (12, 38, N'George Orwell', CAST(0x000004F600000000 AS DateTime), N'1984', CAST(0x0000A15A0181A5C8 AS DateTime))
SET IDENTITY_INSERT [dbo].[People] OFF
SET IDENTITY_INSERT [dbo].[Phones] ON 

INSERT [dbo].[Phones] ([PhoneId], [PersonId], [Type], [Number], [RecordDate]) VALUES (8, 10, 1, N'123123', CAST(0x0000A15A0181BAE0 AS DateTime))
INSERT [dbo].[Phones] ([PhoneId], [PersonId], [Type], [Number], [RecordDate]) VALUES (9, 10, 3, N'123234', CAST(0x0000A15A0181C698 AS DateTime))
INSERT [dbo].[Phones] ([PhoneId], [PersonId], [Type], [Number], [RecordDate]) VALUES (10, 12, 3, N'234234', CAST(0x0000A15A0181D250 AS DateTime))
INSERT [dbo].[Phones] ([PhoneId], [PersonId], [Type], [Number], [RecordDate]) VALUES (11, 12, 1, N'234345', CAST(0x0000A15A0181DA84 AS DateTime))
INSERT [dbo].[Phones] ([PhoneId], [PersonId], [Type], [Number], [RecordDate]) VALUES (12, 9, 1, N'345345', CAST(0x0000A15A0181E768 AS DateTime))
INSERT [dbo].[Phones] ([PhoneId], [PersonId], [Type], [Number], [RecordDate]) VALUES (13, 11, 1, N'456456', CAST(0x0000A15A0181F44C AS DateTime))
INSERT [dbo].[Phones] ([PhoneId], [PersonId], [Type], [Number], [RecordDate]) VALUES (14, 11, 2, N'456567', CAST(0x0000A15A0181FB54 AS DateTime))
INSERT [dbo].[Phones] ([PhoneId], [PersonId], [Type], [Number], [RecordDate]) VALUES (15, 11, 3, N'567678', CAST(0x0000A15A0182025C AS DateTime))
SET IDENTITY_INSERT [dbo].[Phones] OFF
ALTER TABLE [dbo].[People] ADD  CONSTRAINT [DF_People_RecordDate]  DEFAULT (getdate()) FOR [RecordDate]
GO
ALTER TABLE [dbo].[Phones] ADD  CONSTRAINT [DF_Phones_RecordDate]  DEFAULT (getdate()) FOR [RecordDate]
GO
USE [master]
GO
ALTER DATABASE [PhoneBook] SET  READ_WRITE 
GO

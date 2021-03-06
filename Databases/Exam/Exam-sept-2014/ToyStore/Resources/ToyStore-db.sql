CREATE DATABASE ToysStore
GO
USE ToysStore
GO
/****** Object:  Table [dbo].[AgeRanges]    Script Date: 9/7/2014 10:14:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgeRanges](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[minAge] [int] NOT NULL,
	[maxAge] [int] NULL,
 CONSTRAINT [PK_AgeRanges] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 9/7/2014 10:14:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Manufacturers]    Script Date: 9/7/2014 10:14:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[country] [nvarchar](50) NULL,
 CONSTRAINT [PK_Manufacturers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Name] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Toys]    Script Date: 9/7/2014 10:14:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Toys](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[type] [nvarchar](50) NULL,
	[categoryId] [int] NOT NULL,
	[manufacturerId] [int] NOT NULL,
	[price] [money] NOT NULL,
	[color] [nvarchar](50) NULL,
	[ageRangeId] [int] NOT NULL,
 CONSTRAINT [PK_Toys] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ToysCategories]    Script Date: 9/7/2014 10:14:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToysCategories](
	[toyId] [int] NOT NULL,
	[categoryId] [int] NOT NULL,
 CONSTRAINT [PK_ToysCategories] PRIMARY KEY CLUSTERED 
(
	[toyId] ASC,
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Toys]  WITH CHECK ADD  CONSTRAINT [FK_Toys_AgeRanges] FOREIGN KEY([ageRangeId])
REFERENCES [dbo].[AgeRanges] ([id])
GO
ALTER TABLE [dbo].[Toys] CHECK CONSTRAINT [FK_Toys_AgeRanges]
GO
ALTER TABLE [dbo].[Toys]  WITH CHECK ADD  CONSTRAINT [FK_Toys_Manufacturers] FOREIGN KEY([manufacturerId])
REFERENCES [dbo].[Manufacturers] ([id])
GO
ALTER TABLE [dbo].[Toys] CHECK CONSTRAINT [FK_Toys_Manufacturers]
GO
ALTER TABLE [dbo].[ToysCategories]  WITH CHECK ADD  CONSTRAINT [FK_ToysCategories_Categories] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[ToysCategories] CHECK CONSTRAINT [FK_ToysCategories_Categories]
GO
ALTER TABLE [dbo].[ToysCategories]  WITH CHECK ADD  CONSTRAINT [FK_ToysCategories_Toys] FOREIGN KEY([toyId])
REFERENCES [dbo].[Toys] ([id])
GO
ALTER TABLE [dbo].[ToysCategories] CHECK CONSTRAINT [FK_ToysCategories_Toys]
GO

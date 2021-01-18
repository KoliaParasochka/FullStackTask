USE [CoursesDb]
GO

/****** Object:  Table [dbo].[Course]    Script Date: 18.01.2021 8:04:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Course](
	[Id] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[DayOfWeek] [nvarchar](50) NULL,
	[TimeStart] [time](7) NULL,
	[TimeEnd] [time](7) NULL,
	[Price] [decimal](18, 0) NULL
) ON [PRIMARY]
GO



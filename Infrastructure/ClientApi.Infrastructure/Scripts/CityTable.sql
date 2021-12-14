USE [ClientDB]
GO

/****** Object:  Table [dbo].[City]    Script Date: 14/12/2021 10:47:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[City](
	[Name] [nvarchar](100) NOT NULL,
	[State] [nvarchar](100) NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[InclusionDate] [datetime2](7) NOT NULL,
	[LastChangeDate] [datetime2](7) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


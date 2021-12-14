USE [ClientDB]
GO

/****** Object:  Table [dbo].[Client]    Script Date: 14/12/2021 10:47:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Client](
	[Id] [uniqueidentifier] NOT NULL,
	[InclusionDate] [datetime2](7) NOT NULL,
	[LastChangeDate] [datetime2](7) NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Gender] [nvarchar](15) NOT NULL,
	[BirthDate] [datetime2](7) NOT NULL,
	[Age] [int] NOT NULL,
	[CityId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Client]  WITH CHECK ADD FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO

ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO

ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_City]
GO



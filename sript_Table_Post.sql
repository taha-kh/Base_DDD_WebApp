USE [WebApp]
GO

/****** Object:  Table [dbo].[Post]    Script Date: 22/01/2016 18:11:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Post](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[PublicationDate] [date] NULL,
	[CreationDate] [date] NOT NULL,
	[UpdateDate] [date] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


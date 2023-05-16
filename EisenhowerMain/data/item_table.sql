USE [matrix]
GO

/****** Object:  Table [dbo].[items]    Script Date: 17.05.2023 00:21:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[items](
	[title] [text] NOT NULL,
	[deadline] [datetime] NOT NULL,
	[isImportant] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


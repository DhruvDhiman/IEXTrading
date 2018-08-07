USE [TradingData]
GO

/****** Object:  Table [dbo].[Companies]    Script Date: 7/26/2018 7:49:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Companies](
	[symbol] [varchar](32) NOT NULL,
	[name] [varchar](128) NULL,
	[date] [varchar](16) NULL,
	[isEnabled] [bit] NULL,
	[type] [varchar](8) NULL,
	[iexId] [varchar](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[symbol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



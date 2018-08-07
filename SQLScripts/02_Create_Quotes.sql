USE [TradingData]
GO

/****** Object:  Table [dbo].[Quotes]    Script Date: 7/26/2018 7:51:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Quotes](
	[QuoteId] [int] IDENTITY(1,1) NOT NULL,
	[symbol] [varchar](128) NULL,
	[companyName] [varchar](128) NULL,
	[primaryExchange] [varchar](128) NULL,
	[sector] [varchar](128) NULL,
	[calculationPrice] [varchar](128) NULL,
	[open] [real] NULL,
	[openTime] [bigint] NULL,
	[close] [real] NULL,
	[closeTime] [bigint] NULL,
	[high] [real] NULL,
	[low] [real] NULL,
	[latestPrice] [real] NULL,
	[latestSource] [varchar](128) NULL,
	[latestTime] [varchar](128) NULL,
	[latestUpdate] [bigint] NULL,
	[latestVolume] [real] NULL,
	[iexRealtimePrice] [real] NULL,
	[iexRealtimeSize] [real] NULL,
	[iexLastUpdated] [bigint] NULL,
	[delayedPrice] [real] NULL,
	[delayedPriceTime] [bigint] NULL,
	[extendedPrice] [real] NULL,
	[extendedChange] [real] NULL,
	[extendedChangePercent] [real] NULL,
	[extendedPriceTime] [bigint] NULL,
	[previousClose] [real] NULL,
	[change] [real] NULL,
	[changePercent] [real] NULL,
	[iexMarketPercent] [real] NULL,
	[iexVolume] [real] NULL,
	[avgTotalVolume] [int] NULL,
	[iexBidPrice] [real] NULL,
	[iexBidSize] [real] NULL,
	[iexAskPrice] [real] NULL,
	[iexAskSize] [real] NULL,
	[marketCap] [bigint] NULL,
	[peRatio] [real] NULL,
	[week52High] [real] NULL,
	[week52Low] [real] NULL,
	[ytdChange] [real] NULL,
PRIMARY KEY CLUSTERED 
(
	[QuoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



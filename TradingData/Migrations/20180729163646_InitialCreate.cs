using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TradingData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    symbol = table.Column<string>(nullable: false),
                    date = table.Column<string>(nullable: true),
                    iexId = table.Column<string>(nullable: true),
                    isEnabled = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.symbol);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    avgTotalVolume = table.Column<int>(nullable: false),
                    calculationPrice = table.Column<string>(nullable: true),
                    change = table.Column<float>(nullable: false),
                    changePercent = table.Column<float>(nullable: false),
                    close = table.Column<float>(nullable: false),
                    closeTime = table.Column<long>(nullable: false),
                    companyName = table.Column<string>(nullable: true),
                    delayedPrice = table.Column<float>(nullable: false),
                    delayedPriceTime = table.Column<long>(nullable: false),
                    extendedChange = table.Column<float>(nullable: false),
                    extendedChangePercent = table.Column<float>(nullable: false),
                    extendedPrice = table.Column<float>(nullable: false),
                    extendedPriceTime = table.Column<long>(nullable: false),
                    high = table.Column<float>(nullable: false),
                    iexAskPrice = table.Column<float>(nullable: false),
                    iexAskSize = table.Column<float>(nullable: false),
                    iexBidPrice = table.Column<float>(nullable: false),
                    iexBidSize = table.Column<float>(nullable: false),
                    iexLastUpdated = table.Column<long>(nullable: false),
                    iexMarketPercent = table.Column<float>(nullable: false),
                    iexRealtimePrice = table.Column<float>(nullable: false),
                    iexRealtimeSize = table.Column<float>(nullable: false),
                    iexVolume = table.Column<float>(nullable: false),
                    latestPrice = table.Column<float>(nullable: false),
                    latestSource = table.Column<string>(nullable: true),
                    latestTime = table.Column<string>(nullable: true),
                    latestUpdate = table.Column<long>(nullable: false),
                    latestVolume = table.Column<float>(nullable: false),
                    low = table.Column<float>(nullable: false),
                    marketCap = table.Column<long>(nullable: false),
                    open = table.Column<float>(nullable: false),
                    openTime = table.Column<long>(nullable: false),
                    peRatio = table.Column<float>(nullable: false),
                    previousClose = table.Column<float>(nullable: false),
                    primaryExchange = table.Column<string>(nullable: true),
                    sector = table.Column<string>(nullable: true),
                    symbol = table.Column<string>(nullable: true),
                    week52High = table.Column<float>(nullable: false),
                    week52Low = table.Column<float>(nullable: false),
                    ytdChange = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}

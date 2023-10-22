using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Auction.Migrations.AuctionDb
{
    /// <inheritdoc />
    public partial class Bids_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "EndTime",
                value: new DateTime(2023, 10, 22, 14, 17, 10, 742, DateTimeKind.Local).AddTicks(4798));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "EndTime",
                value: new DateTime(2023, 10, 21, 23, 10, 22, 658, DateTimeKind.Local).AddTicks(7341));
        }
    }
}

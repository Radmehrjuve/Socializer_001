using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Socializer_001.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldsCompleteApplicationUserCLass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "ArrivalDate",
                table: "AspNetUsers",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "sex",
                table: "AspNetUsers",
                type: "smallint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "sex",
                table: "AspNetUsers");
        }
    }
}

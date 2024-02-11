using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P.F.M.Migrations
{
    /// <inheritdoc />
    public partial class AddMethotds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTransaction",
                table: "PFMTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 11, 13, 31, 25, 15, DateTimeKind.Local).AddTicks(2744),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 10, 22, 10, 1, 509, DateTimeKind.Local).AddTicks(5517));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTransaction",
                table: "PFMTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 10, 22, 10, 1, 509, DateTimeKind.Local).AddTicks(5517),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 11, 13, 31, 25, 15, DateTimeKind.Local).AddTicks(2744));
        }
    }
}

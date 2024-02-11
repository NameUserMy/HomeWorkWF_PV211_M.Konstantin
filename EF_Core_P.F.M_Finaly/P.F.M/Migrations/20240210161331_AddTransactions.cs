using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P.F.M.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PFMTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTransaction = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 10, 18, 13, 30, 708, DateTimeKind.Local).AddTicks(1010)),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PFMTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PFMTransactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PFMTransactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperation_PFMTransactions_PFMTransactionId",
                        column: x => x.PFMTransactionId,
                        principalTable: "PFMTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PFMTransactions_UserId",
                table: "PFMTransactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperation_PFMTransactionId",
                table: "UserOperation",
                column: "PFMTransactionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserOperation");

            migrationBuilder.DropTable(
                name: "PFMTransactions");
        }
    }
}

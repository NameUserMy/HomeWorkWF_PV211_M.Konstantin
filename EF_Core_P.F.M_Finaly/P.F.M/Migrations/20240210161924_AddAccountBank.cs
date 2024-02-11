using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P.F.M.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountBank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperation_PFMTransactions_PFMTransactionId",
                table: "UserOperation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOperation",
                table: "UserOperation");

            migrationBuilder.RenameTable(
                name: "UserOperation",
                newName: "Operations");

            migrationBuilder.RenameIndex(
                name: "IX_UserOperation_PFMTransactionId",
                table: "Operations",
                newName: "IX_Operations_PFMTransactionId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTransaction",
                table: "PFMTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 10, 18, 19, 23, 755, DateTimeKind.Local).AddTicks(8116),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 10, 18, 13, 30, 708, DateTimeKind.Local).AddTicks(1010));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operations",
                table: "Operations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoneyAccount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_UserId",
                table: "BankAccounts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_PFMTransactions_PFMTransactionId",
                table: "Operations",
                column: "PFMTransactionId",
                principalTable: "PFMTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_PFMTransactions_PFMTransactionId",
                table: "Operations");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operations",
                table: "Operations");

            migrationBuilder.RenameTable(
                name: "Operations",
                newName: "UserOperation");

            migrationBuilder.RenameIndex(
                name: "IX_Operations_PFMTransactionId",
                table: "UserOperation",
                newName: "IX_UserOperation_PFMTransactionId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTransaction",
                table: "PFMTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 10, 18, 13, 30, 708, DateTimeKind.Local).AddTicks(1010),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 10, 18, 19, 23, 755, DateTimeKind.Local).AddTicks(8116));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOperation",
                table: "UserOperation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperation_PFMTransactions_PFMTransactionId",
                table: "UserOperation",
                column: "PFMTransactionId",
                principalTable: "PFMTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

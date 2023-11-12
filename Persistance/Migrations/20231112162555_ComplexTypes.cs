using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ComplexTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "MaximumAmount",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "Budgets");

            migrationBuilder.AddColumn<int>(
                name: "Amount_Currency",
                table: "Expenses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount_Quantity",
                table: "Expenses",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MaximumAmount_Amount",
                table: "Budgets",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MaximumAmount_Currency",
                table: "Budgets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Period_EndDate",
                table: "Budgets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Period_StartDate",
                table: "Budgets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "BudgetAlert",
                columns: table => new
                {
                    BudgetAlertId = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    AlertingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetAlert", x => x.BudgetAlertId);
                });

            migrationBuilder.CreateTable(
                name: "BudgetRecord",
                columns: table => new
                {
                    BudgetRecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpenseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetRecord", x => x.BudgetRecordId);
                });

            migrationBuilder.CreateTable(
                name: "BudgetBudgetAlert",
                columns: table => new
                {
                    AlertsBudgetAlertId = table.Column<Guid>(type: "uuid", nullable: false),
                    BudgetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetBudgetAlert", x => new { x.AlertsBudgetAlertId, x.BudgetId });
                    table.ForeignKey(
                        name: "FK_BudgetBudgetAlert_BudgetAlert_AlertsBudgetAlertId",
                        column: x => x.AlertsBudgetAlertId,
                        principalTable: "BudgetAlert",
                        principalColumn: "BudgetAlertId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BudgetBudgetAlert_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BudgetBudgetRecord",
                columns: table => new
                {
                    BudgetId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecordsBudgetRecordId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetBudgetRecord", x => new { x.BudgetId, x.RecordsBudgetRecordId });
                    table.ForeignKey(
                        name: "FK_BudgetBudgetRecord_BudgetRecord_RecordsBudgetRecordId",
                        column: x => x.RecordsBudgetRecordId,
                        principalTable: "BudgetRecord",
                        principalColumn: "BudgetRecordId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BudgetBudgetRecord_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetAlert_BudgetAlertId",
                table: "BudgetAlert",
                column: "BudgetAlertId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetBudgetAlert_BudgetId",
                table: "BudgetBudgetAlert",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetBudgetRecord_RecordsBudgetRecordId",
                table: "BudgetBudgetRecord",
                column: "RecordsBudgetRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetRecord_BudgetRecordId",
                table: "BudgetRecord",
                column: "BudgetRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetBudgetAlert");

            migrationBuilder.DropTable(
                name: "BudgetBudgetRecord");

            migrationBuilder.DropTable(
                name: "BudgetAlert");

            migrationBuilder.DropTable(
                name: "BudgetRecord");

            migrationBuilder.DropColumn(
                name: "Amount_Currency",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Amount_Quantity",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "MaximumAmount_Amount",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "MaximumAmount_Currency",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "Period_EndDate",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "Period_StartDate",
                table: "Budgets");

            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "Expenses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaximumAmount",
                table: "Budgets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Period",
                table: "Budgets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}

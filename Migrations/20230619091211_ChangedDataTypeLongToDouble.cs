using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditContolTrackerAPIs.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDataTypeLongToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "RecOrigCurrAmount",
                table: "Receipts",
                type: "float",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Column8",
                table: "Receipts",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "AmountInUsd",
                table: "Receipts",
                type: "float",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Usdbalance",
                table: "InvoiceDetails",
                type: "float",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "FusionAccountNumber",
                table: "InvoiceDetails",
                type: "float",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CreditUsdamount",
                table: "InvoiceDetails",
                type: "float",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CreditNoteDiscounts",
                table: "InvoiceDetails",
                type: "float",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "BalanceInUsd",
                table: "InvoiceDetails",
                type: "float",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "BalanceInCurrency",
                table: "InvoiceDetails",
                type: "float",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AnalyticReports",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditChange = table.Column<int>(type: "int", nullable: true),
                    BalanceInUsd = table.Column<double>(type: "float", nullable: false),
                    CompanyCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalyticReports", x => x.InvoiceNo);
                });

            migrationBuilder.CreateTable(
                name: "Predictions",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BalanceInUsd = table.Column<double>(type: "float", nullable: true),
                    Predicted_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predictions", x => x.InvoiceNo);
                });

            migrationBuilder.CreateTable(
                name: "TotalAnalysis",
                columns: table => new
                {
                    pending_invoices = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paid_invoices = table.Column<int>(type: "int", nullable: false),
                    late_Paid_invoices = table.Column<int>(type: "int", nullable: false),
                    pending_revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total_Revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total_invoices = table.Column<int>(type: "int", nullable: false),
                    percentageOfPendingInvoices = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    percentageOfRevenueOnHold = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalAnalysis", x => x.pending_invoices);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalyticReports");

            migrationBuilder.DropTable(
                name: "Predictions");

            migrationBuilder.DropTable(
                name: "TotalAnalysis");

            migrationBuilder.AlterColumn<long>(
                name: "RecOrigCurrAmount",
                table: "Receipts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Column8",
                table: "Receipts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "AmountInUsd",
                table: "Receipts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Usdbalance",
                table: "InvoiceDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FusionAccountNumber",
                table: "InvoiceDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreditUsdamount",
                table: "InvoiceDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreditNoteDiscounts",
                table: "InvoiceDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BalanceInUsd",
                table: "InvoiceDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BalanceInCurrency",
                table: "InvoiceDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}

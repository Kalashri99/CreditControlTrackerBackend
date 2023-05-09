using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditContolTrackerAPIs.Migrations
{
    /// <inheritdoc />
    public partial class ChangedForeignKeyNameinReceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_InvoiceDetails_InvoiceDetailInvoiceNo",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_InvoiceDetailInvoiceNo",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "InvoiceDetailInvoiceNo",
                table: "Receipts");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNo",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_InvoiceNo",
                table: "Receipts",
                column: "InvoiceNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_InvoiceDetails_InvoiceNo",
                table: "Receipts",
                column: "InvoiceNo",
                principalTable: "InvoiceDetails",
                principalColumn: "InvoiceNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_InvoiceDetails_InvoiceNo",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_InvoiceNo",
                table: "Receipts");

            migrationBuilder.AlterColumn<long>(
                name: "InvoiceNo",
                table: "Receipts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceDetailInvoiceNo",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_InvoiceDetailInvoiceNo",
                table: "Receipts",
                column: "InvoiceDetailInvoiceNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_InvoiceDetails_InvoiceDetailInvoiceNo",
                table: "Receipts",
                column: "InvoiceDetailInvoiceNo",
                principalTable: "InvoiceDetails",
                principalColumn: "InvoiceNo");
        }
    }
}

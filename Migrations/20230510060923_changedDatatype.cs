using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditContolTrackerAPIs.Migrations
{
    /// <inheritdoc />
    public partial class changedDatatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Customers_CostumerId",
                table: "InvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "CostumerId",
                table: "InvoiceDetails",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDetails_CostumerId",
                table: "InvoiceDetails",
                newName: "IX_InvoiceDetails_CustomerId");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "InvoiceDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Customers_CustomerId",
                table: "InvoiceDetails",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Customers_CustomerId",
                table: "InvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "InvoiceDetails",
                newName: "CostumerId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDetails_CustomerId",
                table: "InvoiceDetails",
                newName: "IX_InvoiceDetails_CostumerId");

            migrationBuilder.AlterColumn<long>(
                name: "Currency",
                table: "InvoiceDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Customers_CostumerId",
                table: "InvoiceDetails",
                column: "CostumerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

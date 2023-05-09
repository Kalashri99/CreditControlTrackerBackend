using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditContolTrackerAPIs.Migrations
{
    /// <inheritdoc />
    public partial class RenameForiegnKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Costumers_CostumerId",
                table: "InvoiceDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Costumers",
                table: "Costumers");

            migrationBuilder.RenameTable(
                name: "Costumers",
                newName: "Customers");

            migrationBuilder.RenameColumn(
                name: "InvoiceDetailId",
                table: "Receipts",
                newName: "InvoiceNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Customers_CostumerId",
                table: "InvoiceDetails",
                column: "CostumerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Customers_CostumerId",
                table: "InvoiceDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Costumers");

            migrationBuilder.RenameColumn(
                name: "InvoiceNo",
                table: "Receipts",
                newName: "InvoiceDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Costumers",
                table: "Costumers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Costumers_CostumerId",
                table: "InvoiceDetails",
                column: "CostumerId",
                principalTable: "Costumers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

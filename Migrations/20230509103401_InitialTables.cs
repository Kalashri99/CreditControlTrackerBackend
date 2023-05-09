using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditContolTrackerAPIs.Migrations
{
    /// <inheritdoc />
    public partial class InitialTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    AccountTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.AccountTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Agings",
                columns: table => new
                {
                    AgingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgingName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agings", x => x.AgingId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCategories",
                columns: table => new
                {
                    CompanyCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCategories", x => x.CompanyCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Costumers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    EntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceStatuses",
                columns: table => new
                {
                    InvoiceStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceStatuses", x => x.InvoiceStatusId);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTypes",
                columns: table => new
                {
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTypes", x => x.InvoiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PoNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BalanceInCurrency = table.Column<long>(type: "bigint", nullable: false),
                    Currency = table.Column<long>(type: "bigint", nullable: false),
                    Usdbalance = table.Column<long>(type: "bigint", nullable: false),
                    Provisioning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BalanceInUsd = table.Column<long>(type: "bigint", nullable: false),
                    CreditNoteDiscounts = table.Column<long>(type: "bigint", nullable: false),
                    CreditUsdamount = table.Column<long>(type: "bigint", nullable: false),
                    AccountManager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrnFacTuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewBu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArPoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewDu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewOu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false),
                    ContractPartyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectContractId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceManager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesPocasperIms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryPartner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryHead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesPoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesVp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FusionAccountNumber = table.Column<long>(type: "bigint", nullable: false),
                    FusionAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedSalesPoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedSalesVp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountTypeId = table.Column<int>(type: "int", nullable: false),
                    CostumerId = table.Column<int>(type: "int", nullable: false),
                    InvoiceStatusId = table.Column<int>(type: "int", nullable: false),
                    AgingId = table.Column<int>(type: "int", nullable: false),
                    CompanyCategoryId = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.InvoiceNo);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "AccountTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Agings_AgingId",
                        column: x => x.AgingId,
                        principalTable: "Agings",
                        principalColumn: "AgingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_CompanyCategories_CompanyCategoryId",
                        column: x => x.CompanyCategoryId,
                        principalTable: "CompanyCategories",
                        principalColumn: "CompanyCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Costumers_CostumerId",
                        column: x => x.CostumerId,
                        principalTable: "Costumers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_InvoiceStatuses_InvoiceStatusId",
                        column: x => x.InvoiceStatusId,
                        principalTable: "InvoiceStatuses",
                        principalColumn: "InvoiceStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_InvoiceTypes_InvoiceTypeId",
                        column: x => x.InvoiceTypeId,
                        principalTable: "InvoiceTypes",
                        principalColumn: "InvoiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    ReceiptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecOrigCurrAmount = table.Column<long>(type: "bigint", nullable: false),
                    AmountInUsd = table.Column<long>(type: "bigint", nullable: false),
                    ReceivedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckWire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column8 = table.Column<long>(type: "bigint", nullable: false),
                    InvoiceDetailId = table.Column<long>(type: "bigint", nullable: false),
                    InvoiceDetailInvoiceNo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ReceiptId);
                    table.ForeignKey(
                        name: "FK_Receipts_InvoiceDetails_InvoiceDetailInvoiceNo",
                        column: x => x.InvoiceDetailInvoiceNo,
                        principalTable: "InvoiceDetails",
                        principalColumn: "InvoiceNo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_AccountTypeId",
                table: "InvoiceDetails",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_AgingId",
                table: "InvoiceDetails",
                column: "AgingId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_CompanyCategoryId",
                table: "InvoiceDetails",
                column: "CompanyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_CostumerId",
                table: "InvoiceDetails",
                column: "CostumerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_EntityId",
                table: "InvoiceDetails",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceStatusId",
                table: "InvoiceDetails",
                column: "InvoiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceTypeId",
                table: "InvoiceDetails",
                column: "InvoiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_InvoiceDetailInvoiceNo",
                table: "Receipts",
                column: "InvoiceDetailInvoiceNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Agings");

            migrationBuilder.DropTable(
                name: "CompanyCategories");

            migrationBuilder.DropTable(
                name: "Costumers");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "InvoiceStatuses");

            migrationBuilder.DropTable(
                name: "InvoiceTypes");
        }
    }
}

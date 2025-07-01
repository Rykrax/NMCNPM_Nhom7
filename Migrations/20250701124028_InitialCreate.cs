using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NMCNPM_Nhom7.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCustomers",
                columns: table => new
                {
                    iCustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sFullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    sPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    iLoyaltyPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomers", x => x.iCustomerID);
                });

            migrationBuilder.CreateTable(
                name: "tblProductCategories",
                columns: table => new
                {
                    iCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sCategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductCategories", x => x.iCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "tblRoles",
                columns: table => new
                {
                    iRoleID = table.Column<byte>(type: "tinyint", nullable: false),
                    sRoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRoles", x => x.iRoleID);
                });

            migrationBuilder.CreateTable(
                name: "tblSuppliers",
                columns: table => new
                {
                    iSupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sCompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    sAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    sPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    sEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSuppliers", x => x.iSupplierID);
                });

            migrationBuilder.CreateTable(
                name: "tblUnits",
                columns: table => new
                {
                    iUnitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sUnitName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUnits", x => x.iUnitID);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployees",
                columns: table => new
                {
                    iEmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sFullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    bGender = table.Column<bool>(type: "bit", nullable: false),
                    dBirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    sPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    sEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    sCCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    sAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    sPasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    iRoleID = table.Column<byte>(type: "tinyint", nullable: false),
                    sStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, defaultValue: "active")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployees", x => x.iEmployeeID);
                    table.ForeignKey(
                        name: "FK_Roles_iEmployeeID",
                        column: x => x.iRoleID,
                        principalTable: "tblRoles",
                        principalColumn: "iRoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblProducts",
                columns: table => new
                {
                    iProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    iCategoryID = table.Column<int>(type: "int", nullable: true),
                    fPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    iQuantity = table.Column<int>(type: "int", nullable: false),
                    iUnitID = table.Column<int>(type: "int", nullable: true),
                    iSupplierID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProducts", x => x.iProductID);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories",
                        column: x => x.iCategoryID,
                        principalTable: "tblProductCategories",
                        principalColumn: "iCategoryID");
                    table.ForeignKey(
                        name: "FK_Suppliers_iSupplierID",
                        column: x => x.iSupplierID,
                        principalTable: "tblSuppliers",
                        principalColumn: "iSupplierID");
                    table.ForeignKey(
                        name: "FK_Units_iUnitID",
                        column: x => x.iUnitID,
                        principalTable: "tblUnits",
                        principalColumn: "iUnitID");
                });

            migrationBuilder.CreateTable(
                name: "tblInvoices",
                columns: table => new
                {
                    iInvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iEmployeeID = table.Column<int>(type: "int", nullable: true),
                    iCustomerID = table.Column<int>(type: "int", nullable: true),
                    dCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fVAT = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblInvoices", x => x.iInvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers",
                        column: x => x.iCustomerID,
                        principalTable: "tblCustomers",
                        principalColumn: "iCustomerID");
                    table.ForeignKey(
                        name: "FK_Invoices_Employee",
                        column: x => x.iEmployeeID,
                        principalTable: "tblEmployees",
                        principalColumn: "iEmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "tblDiscountedProducts",
                columns: table => new
                {
                    iDiscountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iProductID = table.Column<int>(type: "int", nullable: false),
                    fDiscountPercent = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    fDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDiscountedProducts", x => x.iDiscountID);
                    table.ForeignKey(
                        name: "FK_DiscountedProducts_Product",
                        column: x => x.iProductID,
                        principalTable: "tblProducts",
                        principalColumn: "iProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblInvoiceDetails",
                columns: table => new
                {
                    iInvoiceDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iInvoiceID = table.Column<int>(type: "int", nullable: true),
                    iProductID = table.Column<int>(type: "int", nullable: true),
                    iQuantity = table.Column<int>(type: "int", nullable: false),
                    fUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblInvoiceDetails", x => x.iInvoiceDetailID);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Invoice",
                        column: x => x.iInvoiceID,
                        principalTable: "tblInvoices",
                        principalColumn: "iInvoiceID");
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Product",
                        column: x => x.iProductID,
                        principalTable: "tblProducts",
                        principalColumn: "iProductID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomers_sPhone",
                table: "tblCustomers",
                column: "sPhone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblDiscountedProducts_iProductID",
                table: "tblDiscountedProducts",
                column: "iProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_iRoleID",
                table: "tblEmployees",
                column: "iRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_sCCCD",
                table: "tblEmployees",
                column: "sCCCD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_sEmail",
                table: "tblEmployees",
                column: "sEmail",
                unique: true,
                filter: "[sEmail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_sPhone",
                table: "tblEmployees",
                column: "sPhone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoiceDetails_iInvoiceID",
                table: "tblInvoiceDetails",
                column: "iInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoiceDetails_iProductID",
                table: "tblInvoiceDetails",
                column: "iProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoices_iCustomerID",
                table: "tblInvoices",
                column: "iCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoices_iEmployeeID",
                table: "tblInvoices",
                column: "iEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_iCategoryID",
                table: "tblProducts",
                column: "iCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_iSupplierID",
                table: "tblProducts",
                column: "iSupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_iUnitID",
                table: "tblProducts",
                column: "iUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_tblRoles_sRoleName",
                table: "tblRoles",
                column: "sRoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblSuppliers_sEmail",
                table: "tblSuppliers",
                column: "sEmail",
                unique: true,
                filter: "[sEmail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblSuppliers_sPhone",
                table: "tblSuppliers",
                column: "sPhone",
                unique: true,
                filter: "[sPhone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblUnits_sUnitName",
                table: "tblUnits",
                column: "sUnitName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDiscountedProducts");

            migrationBuilder.DropTable(
                name: "tblInvoiceDetails");

            migrationBuilder.DropTable(
                name: "tblInvoices");

            migrationBuilder.DropTable(
                name: "tblProducts");

            migrationBuilder.DropTable(
                name: "tblCustomers");

            migrationBuilder.DropTable(
                name: "tblEmployees");

            migrationBuilder.DropTable(
                name: "tblProductCategories");

            migrationBuilder.DropTable(
                name: "tblSuppliers");

            migrationBuilder.DropTable(
                name: "tblUnits");

            migrationBuilder.DropTable(
                name: "tblRoles");
        }
    }
}

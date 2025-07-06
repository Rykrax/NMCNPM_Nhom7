using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NMCNPM_Nhom7.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductAndProductDetailsSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_iSupplierID",
                table: "tblProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_iUnitID",
                table: "tblProducts");

            migrationBuilder.DropIndex(
                name: "IX_tblProducts_iSupplierID",
                table: "tblProducts");

            migrationBuilder.DropIndex(
                name: "IX_tblProducts_iUnitID",
                table: "tblProducts");

            migrationBuilder.DropColumn(
                name: "fPrice",
                table: "tblProducts");

            migrationBuilder.DropColumn(
                name: "iQuantity",
                table: "tblProducts");

            migrationBuilder.DropColumn(
                name: "iSupplierID",
                table: "tblProducts");

            migrationBuilder.DropColumn(
                name: "iUnitID",
                table: "tblProducts");

            migrationBuilder.CreateTable(
                name: "tblProductDetails",
                columns: table => new
                {
                    iProductDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iProductID = table.Column<int>(type: "int", nullable: false),
                    iUnitID = table.Column<int>(type: "int", nullable: false),
                    iSupplierID = table.Column<int>(type: "int", nullable: false),
                    fImportPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    fSellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    iQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductDetails", x => x.iProductDetailID);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products",
                        column: x => x.iProductID,
                        principalTable: "tblProducts",
                        principalColumn: "iProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Suppliers",
                        column: x => x.iSupplierID,
                        principalTable: "tblSuppliers",
                        principalColumn: "iSupplierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Units",
                        column: x => x.iUnitID,
                        principalTable: "tblUnits",
                        principalColumn: "iUnitID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProductDetails_iSupplierID",
                table: "tblProductDetails",
                column: "iSupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductDetails_iUnitID",
                table: "tblProductDetails",
                column: "iUnitID");

            migrationBuilder.CreateIndex(
                name: "UQ_ProductSupplierUnit",
                table: "tblProductDetails",
                columns: new[] { "iProductID", "iSupplierID", "iUnitID" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProductDetails");

            migrationBuilder.AddColumn<decimal>(
                name: "fPrice",
                table: "tblProducts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "iQuantity",
                table: "tblProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "iSupplierID",
                table: "tblProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "iUnitID",
                table: "tblProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_iSupplierID",
                table: "tblProducts",
                column: "iSupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_iUnitID",
                table: "tblProducts",
                column: "iUnitID");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_iSupplierID",
                table: "tblProducts",
                column: "iSupplierID",
                principalTable: "tblSuppliers",
                principalColumn: "iSupplierID");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_iUnitID",
                table: "tblProducts",
                column: "iUnitID",
                principalTable: "tblUnits",
                principalColumn: "iUnitID");
        }
    }
}

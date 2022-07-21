using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagementSystem.Data.Migrations
{
    public partial class LinkingProductAndProductLocationForStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Stock");

            migrationBuilder.RenameColumn(
                name: "SKU",
                table: "Stock",
                newName: "ProductLocationId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Stock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductId",
                table: "Stock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductLocationId",
                table: "Stock",
                column: "ProductLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Product_ProductId",
                table: "Stock",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_ProductLocation_ProductLocationId",
                table: "Stock",
                column: "ProductLocationId",
                principalTable: "ProductLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Product_ProductId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_ProductLocation_ProductLocationId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_ProductId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_ProductLocationId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Stock");

            migrationBuilder.RenameColumn(
                name: "ProductLocationId",
                table: "Stock",
                newName: "SKU");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Stock",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}

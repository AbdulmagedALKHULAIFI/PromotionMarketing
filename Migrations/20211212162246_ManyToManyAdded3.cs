using Microsoft.EntityFrameworkCore.Migrations;

namespace PromotionMarketing.Migrations
{
    public partial class ManyToManyAdded3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Op_Ops_OpId",
                table: "Product_Op");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Op_Products_ProductId",
                table: "Product_Op");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product_Op",
                table: "Product_Op");

            migrationBuilder.RenameTable(
                name: "Product_Op",
                newName: "Products_Ops");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Op_ProductId",
                table: "Products_Ops",
                newName: "IX_Products_Ops_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Op_OpId",
                table: "Products_Ops",
                newName: "IX_Products_Ops_OpId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products_Ops",
                table: "Products_Ops",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Ops_Ops_OpId",
                table: "Products_Ops",
                column: "OpId",
                principalTable: "Ops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Ops_Products_ProductId",
                table: "Products_Ops",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Ops_Ops_OpId",
                table: "Products_Ops");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Ops_Products_ProductId",
                table: "Products_Ops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products_Ops",
                table: "Products_Ops");

            migrationBuilder.RenameTable(
                name: "Products_Ops",
                newName: "Product_Op");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Ops_ProductId",
                table: "Product_Op",
                newName: "IX_Product_Op_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Ops_OpId",
                table: "Product_Op",
                newName: "IX_Product_Op_OpId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product_Op",
                table: "Product_Op",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Op_Ops_OpId",
                table: "Product_Op",
                column: "OpId",
                principalTable: "Ops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Op_Products_ProductId",
                table: "Product_Op",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

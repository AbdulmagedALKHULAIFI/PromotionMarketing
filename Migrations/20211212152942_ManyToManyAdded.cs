using Microsoft.EntityFrameworkCore.Migrations;

namespace PromotionMarketing.Migrations
{
    public partial class ManyToManyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Ops_OpId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OpId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OpId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Product_Op",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Op", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Op_Ops_OpId",
                        column: x => x.OpId,
                        principalTable: "Ops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Op_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Op_OpId",
                table: "Product_Op",
                column: "OpId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Op_ProductId",
                table: "Product_Op",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Op");

            migrationBuilder.AddColumn<int>(
                name: "OpId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OpId",
                table: "Products",
                column: "OpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Ops_OpId",
                table: "Products",
                column: "OpId",
                principalTable: "Ops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

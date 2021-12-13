using Microsoft.EntityFrameworkCore.Migrations;

namespace PromotionMarketing.Migrations
{
    public partial class RelationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OpId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OpName",
                table: "Ops",
                type: "nvarchar(max)",
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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "OpName",
                table: "Ops");
        }
    }
}

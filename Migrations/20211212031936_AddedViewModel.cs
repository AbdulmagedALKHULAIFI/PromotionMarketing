using Microsoft.EntityFrameworkCore.Migrations;

namespace PromotionMarketing.Migrations
{
    public partial class AddedViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Ops_OpId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "OpId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Ops_OpId",
                table: "Products",
                column: "OpId",
                principalTable: "Ops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Ops_OpId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "OpId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Ops_OpId",
                table: "Products",
                column: "OpId",
                principalTable: "Ops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

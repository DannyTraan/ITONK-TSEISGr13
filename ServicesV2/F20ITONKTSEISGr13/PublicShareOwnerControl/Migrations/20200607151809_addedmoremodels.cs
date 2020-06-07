using Microsoft.EntityFrameworkCore.Migrations;

namespace PublicShareOwnerControl.Migrations
{
    public partial class addedmoremodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockAmount",
                table: "StockInformation");

            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "StockInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "StockInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "StockInformation");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "StockInformation");

            migrationBuilder.AddColumn<int>(
                name: "StockAmount",
                table: "StockInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

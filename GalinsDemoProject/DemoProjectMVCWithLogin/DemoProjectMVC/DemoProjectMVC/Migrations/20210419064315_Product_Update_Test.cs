using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoProjectMVC.Migrations
{
    public partial class Product_Update_Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sthNew",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sthNew",
                table: "Products");
        }
    }
}

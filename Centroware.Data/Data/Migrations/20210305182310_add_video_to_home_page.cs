using Microsoft.EntityFrameworkCore.Migrations;

namespace Centroware.Data.Data.Migrations
{
    public partial class add_video_to_home_page : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SliderMobileImage",
                table: "HomeSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SliderVideo",
                table: "HomeSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderMobileImage",
                table: "HomeSettings");

            migrationBuilder.DropColumn(
                name: "SliderVideo",
                table: "HomeSettings");
        }
    }
}

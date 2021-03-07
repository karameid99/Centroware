using Microsoft.EntityFrameworkCore.Migrations;

namespace Centroware.Data.Data.Migrations
{
    public partial class add_string_work_id_to_work_and_article_tabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkStringId",
                table: "Works",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkStringId",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkStringId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "WorkStringId",
                table: "Articles");
        }
    }
}

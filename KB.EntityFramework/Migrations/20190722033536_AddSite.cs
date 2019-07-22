using Microsoft.EntityFrameworkCore.Migrations;

namespace KB.EntityFramework.Migrations
{
    public partial class AddSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                table: "t_KB_Tag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                table: "t_KB_Article",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "t_KB_Tag");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "t_KB_Article");
        }
    }
}

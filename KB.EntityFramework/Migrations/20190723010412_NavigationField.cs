using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KB.EntityFramework.Migrations
{
    public partial class NavigationField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "t_KB_Article",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "t_KB_Article",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SiteId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    State = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_KB_ArticlesTagsRelation_TagId",
                table: "t_KB_ArticlesTagsRelation",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_t_KB_Article_CategoryId",
                table: "t_KB_Article",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_t_KB_Article_Category_CategoryId",
                table: "t_KB_Article",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_t_KB_ArticlesTagsRelation_t_KB_Article_ArticleId",
                table: "t_KB_ArticlesTagsRelation",
                column: "ArticleId",
                principalTable: "t_KB_Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_KB_ArticlesTagsRelation_t_KB_Tag_TagId",
                table: "t_KB_ArticlesTagsRelation",
                column: "TagId",
                principalTable: "t_KB_Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_KB_Article_Category_CategoryId",
                table: "t_KB_Article");

            migrationBuilder.DropForeignKey(
                name: "FK_t_KB_ArticlesTagsRelation_t_KB_Article_ArticleId",
                table: "t_KB_ArticlesTagsRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_t_KB_ArticlesTagsRelation_t_KB_Tag_TagId",
                table: "t_KB_ArticlesTagsRelation");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_t_KB_ArticlesTagsRelation_TagId",
                table: "t_KB_ArticlesTagsRelation");

            migrationBuilder.DropIndex(
                name: "IX_t_KB_Article_CategoryId",
                table: "t_KB_Article");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "t_KB_Article");

            migrationBuilder.DropColumn(
                name: "State",
                table: "t_KB_Article");
        }
    }
}

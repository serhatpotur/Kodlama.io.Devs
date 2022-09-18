using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class updataEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Social_Developers_DeveloperId",
                table: "Social");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Social",
                table: "Social");

            migrationBuilder.RenameTable(
                name: "Social",
                newName: "SocialMedias");

            migrationBuilder.RenameIndex(
                name: "IX_Social_DeveloperId",
                table: "SocialMedias",
                newName: "IX_SocialMedias_DeveloperId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialMedias",
                table: "SocialMedias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_Developers_DeveloperId",
                table: "SocialMedias",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_Developers_DeveloperId",
                table: "SocialMedias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialMedias",
                table: "SocialMedias");

            migrationBuilder.RenameTable(
                name: "SocialMedias",
                newName: "Social");

            migrationBuilder.RenameIndex(
                name: "IX_SocialMedias_DeveloperId",
                table: "Social",
                newName: "IX_Social_DeveloperId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Social",
                table: "Social",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Social_Developers_DeveloperId",
                table: "Social",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

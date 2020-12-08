using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleMVCApp.Migrations
{
    public partial class connectModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Post",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonKey",
                table: "Post",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_PersonKey",
                table: "Post",
                column: "PersonKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Person_PersonKey",
                table: "Post",
                column: "PersonKey",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Person_PersonKey",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_PersonKey",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "PersonKey",
                table: "Post");
        }
    }
}

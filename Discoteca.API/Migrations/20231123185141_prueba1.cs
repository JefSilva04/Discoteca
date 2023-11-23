using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Discoteca.API.Migrations
{
    /// <inheritdoc />
    public partial class prueba1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentId",
                table: "Attentions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Attentions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attentions_UserId",
                table: "Attentions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attentions_AspNetUsers_UserId",
                table: "Attentions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attentions_AspNetUsers_UserId",
                table: "Attentions");

            migrationBuilder.DropIndex(
                name: "IX_Attentions_UserId",
                table: "Attentions");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Attentions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Attentions");
        }
    }
}

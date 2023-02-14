using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurferDemo.Migrations
{
    /// <inheritdoc />
    public partial class ImageClassUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Image",
                newName: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_BoardId",
                table: "Image",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Board_BoardId",
                table: "Image",
                column: "BoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Board_BoardId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_BoardId",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "BoardId",
                table: "Image",
                newName: "ItemId");
        }
    }
}

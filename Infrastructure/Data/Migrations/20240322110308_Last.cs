using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExhibitRatingComments_AppUser_UserId",
                table: "ExhibitRatingComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ExhibitRatingComments_Exhibits_ExhibitsId",
                table: "ExhibitRatingComments");

            migrationBuilder.DropIndex(
                name: "IX_ExhibitRatingComments_UserId",
                table: "ExhibitRatingComments");

            migrationBuilder.DropColumn(
                name: "ExhibitId",
                table: "ExhibitRatingComments");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tours",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TourItems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "ExhibitsId",
                table: "ExhibitRatingComments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "ExhibitRatingComments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitRatingComments_AppUserId",
                table: "ExhibitRatingComments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitRatingComments_TourId",
                table: "ExhibitRatingComments",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExhibitRatingComments_AppUser_AppUserId",
                table: "ExhibitRatingComments",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExhibitRatingComments_Exhibits_ExhibitsId",
                table: "ExhibitRatingComments",
                column: "ExhibitsId",
                principalTable: "Exhibits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExhibitRatingComments_Tours_TourId",
                table: "ExhibitRatingComments",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExhibitRatingComments_AppUser_AppUserId",
                table: "ExhibitRatingComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ExhibitRatingComments_Exhibits_ExhibitsId",
                table: "ExhibitRatingComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ExhibitRatingComments_Tours_TourId",
                table: "ExhibitRatingComments");

            migrationBuilder.DropIndex(
                name: "IX_ExhibitRatingComments_AppUserId",
                table: "ExhibitRatingComments");

            migrationBuilder.DropIndex(
                name: "IX_ExhibitRatingComments_TourId",
                table: "ExhibitRatingComments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ExhibitRatingComments");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tours",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TourItems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "ExhibitsId",
                table: "ExhibitRatingComments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ExhibitId",
                table: "ExhibitRatingComments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitRatingComments_UserId",
                table: "ExhibitRatingComments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExhibitRatingComments_AppUser_UserId",
                table: "ExhibitRatingComments",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExhibitRatingComments_Exhibits_ExhibitsId",
                table: "ExhibitRatingComments",
                column: "ExhibitsId",
                principalTable: "Exhibits",
                principalColumn: "Id");
        }
    }
}

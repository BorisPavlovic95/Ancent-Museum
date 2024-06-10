using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExhibitCulture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitCulture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExhibitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    UserEmail = table.Column<string>(type: "TEXT", nullable: true),
                    TourDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserDataFirstName = table.Column<string>(name: "UserData_FirstName", type: "TEXT", nullable: true),
                    UserDataLastName = table.Column<string>(name: "UserData_LastName", type: "TEXT", nullable: true),
                    UserDataPhone = table.Column<string>(name: "UserData_Phone", type: "TEXT", nullable: true),
                    UserDataBirthday = table.Column<string>(name: "UserData_Birthday", type: "TEXT", nullable: true),
                    UserDataFavoriteExhibit = table.Column<string>(name: "UserData_FavoriteExhibit", type: "TEXT", nullable: true),
                    UserDataCity = table.Column<string>(name: "UserData_City", type: "TEXT", nullable: true),
                    Subtotal = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Birthday = table.Column<string>(type: "TEXT", nullable: true),
                    FavoriteExhibit = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    AppUserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exhibits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Century = table.Column<string>(type: "TEXT", nullable: true),
                    Period = table.Column<string>(type: "TEXT", nullable: true),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    TourTime = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    ExhibitCultureId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExhibitTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exhibits_ExhibitCulture_ExhibitCultureId",
                        column: x => x.ExhibitCultureId,
                        principalTable: "ExhibitCulture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exhibits_ExhibitTypes_ExhibitTypeId",
                        column: x => x.ExhibitTypeId,
                        principalTable: "ExhibitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    ExhibitItemTouredExhibitItemId = table.Column<int>(name: "ExhibitItemToured_ExhibitItemId", type: "INTEGER", nullable: true),
                    ExhibitItemTouredExhibitName = table.Column<string>(name: "ExhibitItemToured_ExhibitName", type: "TEXT", nullable: true),
                    ExhibitItemTouredPictureUrl = table.Column<string>(name: "ExhibitItemToured_PictureUrl", type: "TEXT", nullable: true),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    TourId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourItems_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExhibitRatingComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExhibitId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    ExhibitsId = table.Column<int>(type: "INTEGER", nullable: true),
                    TourId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitRatingComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExhibitRatingComments_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExhibitRatingComments_Exhibits_ExhibitsId",
                        column: x => x.ExhibitsId,
                        principalTable: "Exhibits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_AppUserId",
                table: "Address",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitRatingComments_ExhibitsId",
                table: "ExhibitRatingComments",
                column: "ExhibitsId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitRatingComments_UserId",
                table: "ExhibitRatingComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibits_ExhibitCultureId",
                table: "Exhibits",
                column: "ExhibitCultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibits_ExhibitTypeId",
                table: "Exhibits",
                column: "ExhibitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TourItems_TourId",
                table: "TourItems",
                column: "TourId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ExhibitRatingComments");

            migrationBuilder.DropTable(
                name: "TourItems");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "Exhibits");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "ExhibitCulture");

            migrationBuilder.DropTable(
                name: "ExhibitTypes");
        }
    }
}

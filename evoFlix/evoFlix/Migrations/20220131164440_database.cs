using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace evoFlix.Migrations
{
    public partial class database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    ReleaseYear = table.Column<DateTime>(type: "date", nullable: false),
                    Rated = table.Column<int>(type: "int", nullable: false),
                    RunTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DirectorName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Actors = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Plot = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    Poster = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    ImdbRating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    ProfilPitcure = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    ValidAccount = table.Column<bool>(type: "BIT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "SourceTable",
                columns: table => new
                {
                    FimSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmLocation = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    FileModified = table.Column<DateTime>(type: "date", nullable: false),
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceTable", x => x.FimSourceId);
                    table.ForeignKey(
                        name: "FK_SourceTable_FilmTable_FilmId",
                        column: x => x.FilmId,
                        principalTable: "FilmTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubtitleTable",
                columns: table => new
                {
                    SubtitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubtitleLanguage = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SubtitleLocation = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubtitleTable", x => x.SubtitleId);
                    table.ForeignKey(
                        name: "FK_SubtitleTable_FilmTable_FilmId",
                        column: x => x.FilmId,
                        principalTable: "FilmTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchTable",
                columns: table => new
                {
                    WatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WatchedTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "date", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchTable", x => x.WatchId);
                    table.ForeignKey(
                        name: "FK_WatchTable_FilmTable_FilmId",
                        column: x => x.FilmId,
                        principalTable: "FilmTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WatchTable_UserTable_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTable",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SourceTable_FilmId",
                table: "SourceTable",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_SubtitleTable_FilmId",
                table: "SubtitleTable",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchTable_FilmId",
                table: "WatchTable",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchTable_UserId",
                table: "WatchTable",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SourceTable");

            migrationBuilder.DropTable(
                name: "SubtitleTable");

            migrationBuilder.DropTable(
                name: "WatchTable");

            migrationBuilder.DropTable(
                name: "FilmTable");

            migrationBuilder.DropTable(
                name: "UserTable");
        }
    }
}

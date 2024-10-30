using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExcersizeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcersizeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Excersize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false),
                    NumOfSeries = table.Column<int>(type: "INTEGER", nullable: false),
                    NumOfReps = table.Column<int>(type: "INTEGER", nullable: false),
                    ExcersizeTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    SessionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excersize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Excersize_ExcersizeType_ExcersizeTypeId",
                        column: x => x.ExcersizeTypeId,
                        principalTable: "ExcersizeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Excersize_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Excersize_ExcersizeTypeId",
                table: "Excersize",
                column: "ExcersizeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Excersize_SessionId",
                table: "Excersize",
                column: "SessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Excersize");

            migrationBuilder.DropTable(
                name: "ExcersizeType");

            migrationBuilder.DropTable(
                name: "Session");
        }
    }
}

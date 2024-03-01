using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "statuses_20ai24ppy",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses_20ai24ppy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users_types_20ai24ppy",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_types_20ai24ppy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appeals_20ai24ppy",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fio = table.Column<string>(type: "text", nullable: false),
                    telephone_number = table.Column<string>(type: "text", nullable: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appeals_20ai24ppy", x => x.id);
                    table.ForeignKey(
                        name: "FK_appeals_20ai24ppy_statuses_20ai24ppy_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ai24ppy",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_20ai24ppy",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    token = table.Column<string>(type: "text", nullable: true),
                    user_type_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_20ai24ppy", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_20ai24ppy_users_types_20ai24ppy_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "users_types_20ai24ppy",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "statuses_20ai24ppy",
                columns: new[] { "id", "status" },
                values: new object[,]
                {
                    { 1, "active" },
                    { 2, "readed" },
                    { 3, "talked" },
                    { 4, "rejected" },
                    { 5, "consent" }
                });

            migrationBuilder.InsertData(
                table: "users_types_20ai24ppy",
                columns: new[] { "id", "type" },
                values: new object[] { 1, "admin" });

            migrationBuilder.InsertData(
                table: "user_20ai24ppy",
                columns: new[] { "id", "email", "login", "password", "token", "user_type_id" },
                values: new object[] { 1, "aippy@gmail.com", "admin", "PJwNvVwgDOlqB++936LTEcR5HX22nFeLDlnopfT4Syg=", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_appeals_20ai24ppy_status_id",
                table: "appeals_20ai24ppy",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_20ai24ppy_login",
                table: "user_20ai24ppy",
                column: "login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_20ai24ppy_user_type_id",
                table: "user_20ai24ppy",
                column: "user_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appeals_20ai24ppy");

            migrationBuilder.DropTable(
                name: "user_20ai24ppy");

            migrationBuilder.DropTable(
                name: "statuses_20ai24ppy");

            migrationBuilder.DropTable(
                name: "users_types_20ai24ppy");
        }
    }
}

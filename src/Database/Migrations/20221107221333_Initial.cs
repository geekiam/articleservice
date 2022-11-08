using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geekiam.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Articles");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "sources",
                schema: "Articles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Identifier = table.Column<string>(type: "varchar", maxLength: 75, nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    Domain = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    FeedUrl = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    Protocol = table.Column<string>(type: "varchar", maxLength: 7, nullable: false),
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sources", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                schema: "Articles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Title = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    Summary = table.Column<string>(type: "varchar", maxLength: 300, nullable: false),
                    Permalink = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    Published = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_posts_sources_SourceId",
                        column: x => x.SourceId,
                        principalSchema: "Articles",
                        principalTable: "sources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_posts_Permalink_SourceId",
                schema: "Articles",
                table: "posts",
                columns: new[] { "Permalink", "SourceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_posts_SourceId",
                schema: "Articles",
                table: "posts",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_sources_Identifier",
                schema: "Articles",
                table: "sources",
                column: "Identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sources_Name_Domain",
                schema: "Articles",
                table: "sources",
                columns: new[] { "Name", "Domain" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts",
                schema: "Articles");

            migrationBuilder.DropTable(
                name: "sources",
                schema: "Articles");
        }
    }
}

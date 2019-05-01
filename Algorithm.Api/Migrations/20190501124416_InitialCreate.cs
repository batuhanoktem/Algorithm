using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Algorithm.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(maxLength: 200, nullable: false),
                    FirstName = table.Column<string>(maxLength: 200, nullable: true),
                    LastName = table.Column<string>(maxLength: 200, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Password = table.Column<string>(maxLength: 60, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    Phone = table.Column<string>(maxLength: 200, nullable: true),
                    Company = table.Column<string>(maxLength: 200, nullable: true),
                    GraduationYear = table.Column<int>(nullable: false),
                    Bio = table.Column<string>(maxLength: 2000, nullable: true),
                    SocialMedia = table.Column<string>(maxLength: 2000, nullable: true),
                    Photo = table.Column<string>(maxLength: 200, nullable: true),
                    DefaultCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

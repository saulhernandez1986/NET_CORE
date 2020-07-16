using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Job = table.Column<Guid>(nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpiresdAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Job);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}

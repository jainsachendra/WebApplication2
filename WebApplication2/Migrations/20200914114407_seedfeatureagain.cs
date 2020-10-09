using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class seedfeatureagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Feature (Name) VALUES ('Feature1')");
            migrationBuilder.Sql("INSERT INTO Feature (Name) VALUES ('Feature2')");
            migrationBuilder.Sql("INSERT INTO Feature (Name) VALUES ('Feature3')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Features WHERE Name IN ('Feature1', 'Feature2', 'Feature3')");
        }
    }
}

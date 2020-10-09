using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class Seeddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MAKES (NAME) VALUES ('MAKE1')");
            migrationBuilder.Sql("INSERT INTO MAKES (NAME) VALUES ('MAKE2')");
            migrationBuilder.Sql("INSERT INTO MAKES (NAME) VALUES ('MAKE3')");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('MAKE1-ModelA',(SELECT ID FROM Makes WHERE Name='MAKE1') )");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('MAKE1-ModelB',(SELECT ID FROM Makes WHERE Name='MAKE1'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('MAKE1-ModelC',(SELECT ID FROM Makes WHERE Name='MAKE1'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('MAKE2-ModelA',(SELECT ID FROM Makes WHERE Name='MAKE2'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('MAKE2-ModelB',(SELECT ID FROM Makes WHERE Name='MAKE2'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('MAKE2-ModelC',(SELECT ID FROM Makes WHERE Name='MAKE2'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('MAKE3-ModelA',(SELECT ID FROM Makes WHERE Name='MAKE3'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('MAKE3-ModelB',(SELECT ID FROM Makes WHERE Name='MAKE3'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('MAKE3-ModelC',(SELECT ID FROM Makes WHERE Name='MAKE3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM MAKES");

        }
    }
}

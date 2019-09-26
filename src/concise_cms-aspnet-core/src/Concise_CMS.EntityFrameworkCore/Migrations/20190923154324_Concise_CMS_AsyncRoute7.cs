using Microsoft.EntityFrameworkCore.Migrations;

namespace Concise_CMS.Migrations
{
    public partial class Concise_CMS_AsyncRoute7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "concise_asyncroute",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "concise_asyncroute",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}

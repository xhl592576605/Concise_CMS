using Microsoft.EntityFrameworkCore.Migrations;

namespace Concise_CMS.Migrations
{
    public partial class Concise_CMS_AsyncRoute5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "concise_asyncroute",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "concise_asyncroute",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}

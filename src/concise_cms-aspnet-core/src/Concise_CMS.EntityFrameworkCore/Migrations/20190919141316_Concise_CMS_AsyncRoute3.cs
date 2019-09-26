using Microsoft.EntityFrameworkCore.Migrations;

namespace Concise_CMS.Migrations
{
    public partial class Concise_CMS_AsyncRoute3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "concise_asyncroute",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "concise_asyncroute");
        }
    }
}

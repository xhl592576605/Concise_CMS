using Microsoft.EntityFrameworkCore.Migrations;

namespace Concise_CMS.Migrations
{
    public partial class Concise_CMS_AsyncRouteMap3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_concise_asyncroute_map_Name",
                table: "concise_asyncroute_map");

            migrationBuilder.AlterColumn<string>(
                name: "RolesStr",
                table: "concise_asyncroute_map",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "concise_asyncroute_map",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RolesStr",
                table: "concise_asyncroute_map",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "concise_asyncroute_map",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_concise_asyncroute_map_Name",
                table: "concise_asyncroute_map",
                column: "Name",
                unique: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Concise_CMS.Migrations
{
    public partial class Concise_CMS_AsyncRouteMap2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_concise_asyncroutemap",
                table: "concise_asyncroutemap");

            migrationBuilder.RenameTable(
                name: "concise_asyncroutemap",
                newName: "concise_asyncroute_map");

            migrationBuilder.RenameIndex(
                name: "IX_concise_asyncroutemap_Name",
                table: "concise_asyncroute_map",
                newName: "IX_concise_asyncroute_map_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_concise_asyncroute_map",
                table: "concise_asyncroute_map",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_concise_asyncroute_map",
                table: "concise_asyncroute_map");

            migrationBuilder.RenameTable(
                name: "concise_asyncroute_map",
                newName: "concise_asyncroutemap");

            migrationBuilder.RenameIndex(
                name: "IX_concise_asyncroute_map_Name",
                table: "concise_asyncroutemap",
                newName: "IX_concise_asyncroutemap_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_concise_asyncroutemap",
                table: "concise_asyncroutemap",
                column: "Id");
        }
    }
}

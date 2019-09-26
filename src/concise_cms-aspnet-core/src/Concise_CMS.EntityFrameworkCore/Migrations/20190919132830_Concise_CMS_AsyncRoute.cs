using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Concise_CMS.Migrations
{
    public partial class Concise_CMS_AsyncRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "concise_asyncroute_meta",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    RolesStr = table.Column<string>(nullable: true),
                    NoCache = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_asyncroute_meta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concise_asyncroute",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Path = table.Column<string>(nullable: false),
                    Component = table.Column<string>(nullable: false),
                    Redirect = table.Column<string>(nullable: true),
                    Hidden = table.Column<bool>(nullable: false),
                    AlwaysShow = table.Column<bool>(nullable: false),
                    MetaId = table.Column<long>(nullable: true),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_asyncroute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concise_asyncroute_concise_asyncroute_meta_MetaId",
                        column: x => x.MetaId,
                        principalTable: "concise_asyncroute_meta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_concise_asyncroute_concise_asyncroute_ParentId",
                        column: x => x.ParentId,
                        principalTable: "concise_asyncroute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_concise_asyncroute_MetaId",
                table: "concise_asyncroute",
                column: "MetaId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_asyncroute_ParentId",
                table: "concise_asyncroute",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "concise_asyncroute");

            migrationBuilder.DropTable(
                name: "concise_asyncroute_meta");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAbp.AbpModuleHub.Migrations
{
    public partial class Add_AuthorStoreMapping_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUserStoreMappings",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    StoreId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserStoreMappings", x => new { x.StoreId, x.AuthorId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserStoreMappings_StoreId_AuthorId",
                table: "AppUserStoreMappings",
                columns: new[] { "StoreId", "AuthorId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserStoreMappings");
        }
    }
}

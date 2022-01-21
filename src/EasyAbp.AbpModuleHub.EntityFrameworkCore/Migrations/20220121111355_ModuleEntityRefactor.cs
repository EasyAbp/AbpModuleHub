using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAbp.AbpModuleHub.Migrations
{
    public partial class ModuleEntityRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppModules_EasyAbpEShopProductsProducts_ProductId",
                table: "AppModules");

            migrationBuilder.DropIndex(
                name: "IX_AppModules_ProductId",
                table: "AppModules");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "AppModules",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "OriginalPrice",
                table: "AppModules",
                type: "numeric(20,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "AppModules",
                type: "numeric(20,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "AppAuthors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Avatar = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAuthors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppModules_AuthorId",
                table: "AppModules",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppModules_ModuleTypeId",
                table: "AppModules",
                column: "ModuleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppModules_AppAuthors_AuthorId",
                table: "AppModules",
                column: "AuthorId",
                principalTable: "AppAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppModules_AppModuleTypes_ModuleTypeId",
                table: "AppModules",
                column: "ModuleTypeId",
                principalTable: "AppModuleTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppModules_AppAuthors_AuthorId",
                table: "AppModules");

            migrationBuilder.DropForeignKey(
                name: "FK_AppModules_AppModuleTypes_ModuleTypeId",
                table: "AppModules");

            migrationBuilder.DropTable(
                name: "AppAuthors");

            migrationBuilder.DropIndex(
                name: "IX_AppModules_AuthorId",
                table: "AppModules");

            migrationBuilder.DropIndex(
                name: "IX_AppModules_ModuleTypeId",
                table: "AppModules");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "AppModules");

            migrationBuilder.DropColumn(
                name: "OriginalPrice",
                table: "AppModules");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "AppModules");

            migrationBuilder.CreateIndex(
                name: "IX_AppModules_ProductId",
                table: "AppModules",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppModules_EasyAbpEShopProductsProducts_ProductId",
                table: "AppModules",
                column: "ProductId",
                principalTable: "EasyAbpEShopProductsProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

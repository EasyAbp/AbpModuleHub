using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAbp.AbpModuleHub.Migrations
{
    public partial class Add_HubModule_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AppHubModules",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AppHubModules");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAbp.AbpModuleHub.Migrations
{
    public partial class UpgradedToEShop2_9_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ProductDetailId",
                table: "EasyAbpEShopProductsProductViews",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductDetailId",
                table: "EasyAbpEShopProductsProducts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProductDetailModificationTime",
                table: "EasyAbpEShopOrdersOrderLines",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductDetailId",
                table: "EasyAbpEShopOrdersOrderLines",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RefundAmount",
                table: "EasyAbpEShopOrdersOrderExtraFees",
                type: "numeric(20,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopPaymentsRefundItemOrderExtraFees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<string>(type: "text", nullable: true),
                    RefundAmount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    RefundItemId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopPaymentsRefundItemOrderExtraFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EasyAbpEShopPaymentsRefundItemOrderExtraFees_EasyAbpEShopPa~",
                        column: x => x.RefundItemId,
                        principalTable: "EasyAbpEShopPaymentsRefundItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopPaymentsRefundItemOrderExtraFees_RefundItemId",
                table: "EasyAbpEShopPaymentsRefundItemOrderExtraFees",
                column: "RefundItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EasyAbpEShopPaymentsRefundItemOrderExtraFees");

            migrationBuilder.DropColumn(
                name: "ProductDetailId",
                table: "EasyAbpEShopOrdersOrderLines");

            migrationBuilder.DropColumn(
                name: "RefundAmount",
                table: "EasyAbpEShopOrdersOrderExtraFees");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductDetailId",
                table: "EasyAbpEShopProductsProductViews",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductDetailId",
                table: "EasyAbpEShopProductsProducts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProductDetailModificationTime",
                table: "EasyAbpEShopOrdersOrderLines",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}

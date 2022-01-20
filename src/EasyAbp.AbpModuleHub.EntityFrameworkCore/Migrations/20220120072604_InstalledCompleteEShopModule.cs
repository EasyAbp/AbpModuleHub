using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAbp.AbpModuleHub.Migrations
{
    public partial class InstalledCompleteEShopModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EasyAbpEShopOrdersOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    StoreId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderNumber = table.Column<string>(type: "text", nullable: true),
                    CustomerUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderStatus = table.Column<int>(type: "integer", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    ProductTotalPrice = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    ActualTotalPrice = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    CustomerRemark = table.Column<string>(type: "text", nullable: true),
                    StaffRemark = table.Column<string>(type: "text", nullable: true),
                    PaymentId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaidTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CompletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CanceledTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CancellationReason = table.Column<string>(type: "text", nullable: true),
                    ReducedInventoryAfterPlacingTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReducedInventoryAfterPaymentTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PaymentExpiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    table.PrimaryKey("PK_EasyAbpEShopOrdersOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopPaymentsPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    PayeeAccount = table.Column<string>(type: "text", nullable: true),
                    ExternalTradingCode = table.Column<string>(type: "text", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    OriginalPaymentAmount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    PaymentDiscount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    ActualPaymentAmount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    PendingRefundAmount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    CompletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CanceledTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    table.PrimaryKey("PK_EasyAbpEShopPaymentsPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopPaymentsRefunds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaymentId = table.Column<Guid>(type: "uuid", nullable: false),
                    RefundPaymentMethod = table.Column<string>(type: "text", nullable: true),
                    ExternalTradingCode = table.Column<string>(type: "text", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    RefundAmount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    DisplayReason = table.Column<string>(type: "text", nullable: true),
                    CustomerRemark = table.Column<string>(type: "text", nullable: true),
                    StaffRemark = table.Column<string>(type: "text", nullable: true),
                    CompletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CanceledTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    table.PrimaryKey("PK_EasyAbpEShopPaymentsRefunds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopOrdersOrderExtraFees",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Fee = table.Column<decimal>(type: "numeric(20,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopOrdersOrderExtraFees", x => new { x.OrderId, x.Name, x.Key });
                    table.ForeignKey(
                        name: "FK_EasyAbpEShopOrdersOrderExtraFees_EasyAbpEShopOrdersOrders_O~",
                        column: x => x.OrderId,
                        principalTable: "EasyAbpEShopOrdersOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopOrdersOrderLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductSkuId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProductDetailModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProductGroupName = table.Column<string>(type: "text", nullable: true),
                    ProductGroupDisplayName = table.Column<string>(type: "text", nullable: true),
                    ProductUniqueName = table.Column<string>(type: "text", nullable: true),
                    ProductDisplayName = table.Column<string>(type: "text", nullable: true),
                    SkuName = table.Column<string>(type: "text", nullable: true),
                    SkuDescription = table.Column<string>(type: "text", nullable: true),
                    MediaResources = table.Column<string>(type: "text", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    ActualTotalPrice = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    RefundedQuantity = table.Column<int>(type: "integer", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("PK_EasyAbpEShopOrdersOrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EasyAbpEShopOrdersOrderLines_EasyAbpEShopOrdersOrders_Order~",
                        column: x => x.OrderId,
                        principalTable: "EasyAbpEShopOrdersOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopPaymentsPaymentItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemType = table.Column<string>(type: "text", nullable: true),
                    ItemKey = table.Column<string>(type: "text", nullable: true),
                    OriginalPaymentAmount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    PaymentDiscount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    ActualPaymentAmount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    PendingRefundAmount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    StoreId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("PK_EasyAbpEShopPaymentsPaymentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EasyAbpEShopPaymentsPaymentItems_EasyAbpEShopPaymentsPaymen~",
                        column: x => x.PaymentId,
                        principalTable: "EasyAbpEShopPaymentsPayments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopPaymentsRefundItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    CustomerRemark = table.Column<string>(type: "text", nullable: true),
                    StaffRemark = table.Column<string>(type: "text", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    StoreId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    RefundId = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("PK_EasyAbpEShopPaymentsRefundItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EasyAbpEShopPaymentsRefundItems_EasyAbpEShopPaymentsRefunds~",
                        column: x => x.RefundId,
                        principalTable: "EasyAbpEShopPaymentsRefunds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopPaymentsRefundItemOrderLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderLineId = table.Column<Guid>(type: "uuid", nullable: false),
                    RefundedQuantity = table.Column<int>(type: "integer", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    RefundItemId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopPaymentsRefundItemOrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EasyAbpEShopPaymentsRefundItemOrderLines_EasyAbpEShopPaymen~",
                        column: x => x.RefundItemId,
                        principalTable: "EasyAbpEShopPaymentsRefundItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopOrdersOrderLines_OrderId",
                table: "EasyAbpEShopOrdersOrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopOrdersOrders_OrderNumber",
                table: "EasyAbpEShopOrdersOrders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopPaymentsPaymentItems_PaymentId",
                table: "EasyAbpEShopPaymentsPaymentItems",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopPaymentsRefundItemOrderLines_RefundItemId",
                table: "EasyAbpEShopPaymentsRefundItemOrderLines",
                column: "RefundItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopPaymentsRefundItems_RefundId",
                table: "EasyAbpEShopPaymentsRefundItems",
                column: "RefundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EasyAbpEShopOrdersOrderExtraFees");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopOrdersOrderLines");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopPaymentsPaymentItems");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopPaymentsRefundItemOrderLines");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopOrdersOrders");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopPaymentsPayments");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopPaymentsRefundItems");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopPaymentsRefunds");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdersApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedOrderItemsColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "order_items");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "order_items",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "order_items",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "PricePerUnit",
                table: "order_items",
                newName: "price_per_unit");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "order_items",
                newName: "order_id");

            migrationBuilder.RenameColumn(
                name: "LineTotal",
                table: "order_items",
                newName: "line_total");

            migrationBuilder.RenameColumn(
                name: "OrderItemId",
                table: "order_items",
                newName: "order_item_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_items",
                table: "order_items",
                column: "order_item_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_order_items",
                table: "order_items");

            migrationBuilder.RenameTable(
                name: "order_items",
                newName: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrderItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "OrderItems",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "price_per_unit",
                table: "OrderItems",
                newName: "PricePerUnit");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "OrderItems",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "line_total",
                table: "OrderItems",
                newName: "LineTotal");

            migrationBuilder.RenameColumn(
                name: "order_item_id",
                table: "OrderItems",
                newName: "OrderItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "OrderItemId");
        }
    }
}

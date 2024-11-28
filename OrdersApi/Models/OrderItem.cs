using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersApi.Models
{
  [Table("order_items")]
  public class OrderItem
  {
    [Column("order_item_id")]
    public long OrderItemId { get; set; }
    [Column("order_id")]
    public long OrderId { get; set; }
    [Column("product_id")]
    public long ProductId { get; set; }
    [Column("quantity")]
    public int Quantity { get; set; }
    [Column("price_per_unit")]
    public decimal PricePerUnit { get; set; }
    [Column("line_total")]
    public decimal LineTotal { get; set; }
  }
}

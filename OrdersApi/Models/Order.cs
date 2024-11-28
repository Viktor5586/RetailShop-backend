using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersApi.Models
{
  [Table("orders")]
  public class Order
  {
    [Column("order_id")]
    public long OrderId { get; set; }
    [Column("shop_id")]
    public long ShopId { get; set; }
    [Column("customer_id")]
    public long CustomerId { get; set; }
    [Column("order_date")]
    public DateTime OrderDate { get; set; }
    [Column("total_amount")]
    public decimal TotalAmount { get; set; }

    public List<OrderItem> OrderItems { get; set; }
  }
}

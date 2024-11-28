using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Models
{
  [Table("products")]
  public class Product
  {
    [Column("product_id")]
    public long ProductId { get; set; }          
    [Column("product_name")]
    public string ProductName { get; set; }       
    [Column("description")]
    public string Description { get; set; } 
    [Column("price")]
    public decimal Price { get; set; }
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
  }
}

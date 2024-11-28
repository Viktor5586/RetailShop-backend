using System.ComponentModel.DataAnnotations.Schema;

namespace CustomersApi.Models
{
  [Table("customers")]
  public class Customer
  {
    [Column("customer_id")]
    public long CustomerId { get; set; } 
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("phone_number")]
    public string PhoneNumber { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
  }
}

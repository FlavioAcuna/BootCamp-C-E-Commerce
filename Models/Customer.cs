#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [Required]
    public string CustomerName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public List<Order> OrderInCustomer { get; set; }

}
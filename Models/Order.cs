#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    [Required]
    [Range(1, 99, ErrorMessage = "La cantidad debe ser mayor a 1 y menor a 99")]
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public int CustomerId { get; set; }
    public int ProductId { get; set; }

    public Customer? CustomerInOrder { get; set; }

    public Product? ProductInOrder { get; set; }
}
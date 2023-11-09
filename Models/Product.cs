#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [DataType(DataType.ImageUrl)]
    public string ImageUrl { get; set; }
    [Required]
    [Range(1, 99, ErrorMessage = "La cantidad debe ser mayor a 1 y menor a 99")]
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Order> OrderInProduct { get; set; }
}
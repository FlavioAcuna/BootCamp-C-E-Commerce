#pragma warning disable CS8618

namespace E_Commerce.Models;

public class ProductViewModel
{
    public List<Product> productosList { get; set; } = new List<Product>();
    public Product oneProduct { get; set; }
}
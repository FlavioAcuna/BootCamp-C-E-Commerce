#pragma warning disable CS8618

namespace E_Commerce.Models;

public class IndexViewModel
{
    public List<Product> ListaProductos { get; set; } = new List<Product>();
    public List<Customer> ListaCustomers { get; set; } = new List<Customer>();
    public List<Order> ListaOrders { get; set; } = new List<Order>();
}
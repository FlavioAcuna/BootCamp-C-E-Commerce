#pragma warning disable CS8618


namespace E_Commerce.Models;

public class OrderViewModel
{
    public List<Customer> ListaOrders { get; set; } = new List<Customer>();
    public Order AddOrder { get; set; }
    public Customer CustomersOrders { get; set; }
    public List<Product> ListProductOrder { get; set; }
}
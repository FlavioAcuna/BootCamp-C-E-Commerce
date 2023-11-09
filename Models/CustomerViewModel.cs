#pragma warning disable CS8618

namespace E_Commerce.Models;

public class CustomerViewModel
{
    public List<Customer> CustomerList { get; set; } = new List<Customer>();
    public Customer Addcustomer { get; set; }
}

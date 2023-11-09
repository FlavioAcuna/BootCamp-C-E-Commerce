using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        IndexViewModel indexvimo = new IndexViewModel
        {
            ListaProductos = _context.products.ToList(),
            ListaCustomers = _context.customers.OrderByDescending(cu => cu.CreatedAt).ToList()
        };
        return View(indexvimo);
    }
    [HttpGet("products")]
    public IActionResult ProductView()
    {
        ProductViewModel productvimo = new ProductViewModel
        {
            productosList = _context.products.ToList(),
            oneProduct = new Product()
        };
        return View("Product", productvimo);
    }
    [HttpPost("products")]
    public IActionResult AddProduct(Product newProduct)
    {
        ProductViewModel productvimo = new ProductViewModel
        {
            productosList = _context.products.ToList(),
            oneProduct = new Product()
        };
        if (ModelState.IsValid)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("AddProduct", productvimo);
        }
        else
        {
            return View("Product", productvimo);
        }
    }

    [HttpGet("customers")]
    public IActionResult CustomerView()
    {

        CustomerViewModel custovimo = new CustomerViewModel
        {
            CustomerList = _context.customers.ToList(),
            Addcustomer = new Customer()
        };

        return View("Customer", custovimo);
    }

    [HttpGet("orders")]
    public IActionResult OrderView()
    {
        OrderViewModel ordervimo = new OrderViewModel
        {
            ListaOrders = _context.customers.Include(c => c.OrderInCustomer).ThenInclude(p => p.ProductInOrder).ToList(),
            AddOrder = new Order(),
            CustomersOrders = _context.customers.Include(c => c.OrderInCustomer).ThenInclude(p => p.ProductInOrder).FirstOrDefault(),
            ListProductOrder = _context.products.ToList(),
        };
        return View("Order", ordervimo);
    }
    [HttpPost("orders")]
    public IActionResult AddOrder(Order newOrder)
    {
        OrderViewModel ordervimo = new OrderViewModel
        {
            ListaOrders = _context.customers.Include(c => c.OrderInCustomer).ThenInclude(p => p.ProductInOrder).ToList(),
            AddOrder = new Order(),
            CustomersOrders = _context.customers.Include(c => c.OrderInCustomer).ThenInclude(p => p.ProductInOrder).FirstOrDefault(),
            ListProductOrder = _context.products.ToList(),
        };
        if (ModelState.IsValid)
        {
            _context.Add(newOrder);
            _context.SaveChanges();
            return RedirectToAction("OrderView", newOrder);
        }
        else
        {
            return View("Order", ordervimo);
        }
    }

    [HttpPost("customers")]
    public IActionResult AddCustomer(Customer newCustomer)
    {
        CustomerViewModel custovimo = new CustomerViewModel
        {
            CustomerList = _context.customers.ToList(),
            Addcustomer = new Customer()
        };
        if (ModelState.IsValid)
        {
            _context.Add(newCustomer);
            _context.SaveChanges();
            return RedirectToAction("AddCustomer", custovimo);
        }
        else
        {
            return View("Customer", custovimo);
        }
    }
    [HttpPost("customers/{CustomerID}/Destroy")]
    public IActionResult RemoveCustomer(int CustomerID)
    {
        Customer? selectedCustomer = _context.customers.SingleOrDefault(cust => cust.CustomerId == CustomerID);
        CustomerViewModel custovimo = new CustomerViewModel
        {
            CustomerList = _context.customers.ToList(),
            Addcustomer = new Customer()
        };
        _context.Remove(selectedCustomer);
        _context.SaveChanges();
        return RedirectToAction("AddCustomer", custovimo);

    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

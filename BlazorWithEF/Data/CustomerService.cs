namespace BlazorWithEF.Data;

public class CustomerService(ApplicationContext _context) : ICustomerService
{
    public void DeleteCustomer(int id)
    {
        var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }

    public Customer GetCustomerById(int id)
    {
        var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
        return customer;
    }

    public List<Customer> GetCustomers()
    {
        return _context.Customers.ToList();
    }

    public void SaveCustomer(Customer customer)
    {
        if (customer.Id == 0) _context.Customers.Add(customer);
        else _context.Customers.Update(customer);
        _context.SaveChanges();
    }
}

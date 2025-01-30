namespace BlazorWithEF.Data;

public class CustomerService(ApplicationContext _context) : ICustomerService
{
    public async Task DeleteCustomer(int id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Customer> GetCustomerById(int id)
    {
        var customer = await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);
        return customer;
    }

    public async Task<List<Customer>> GetCustomers()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task SaveCustomer(Customer customer)
    {
        if (customer.Id == 0) await _context.Customers.AddAsync(customer);
        else _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }
}

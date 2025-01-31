namespace BlazorWithEF.Data;

public class CustomerService(ApplicationContext _context) : ICustomerService
{
    public async Task<OperationResult<bool>> AddCustomer(Customer customer)
    {
        try
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return OperationResultWrapper.Success(true, "avelacvec");
        }
        catch (Exception ex)
        {
            return OperationResultWrapper.Failure<bool>($"error customerin avelacneluc:{ex.Message}");
        }
    }

    //public async Task AddCustomer(Customer customer)
    //{
    //    await _context.Customers.AddAsync(customer);
    //    await _context.SaveChangesAsync();
    //}

    //public async Task DeleteCustomer(int id)
    //{
    //    var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
    //    if (customer != null)
    //    {
    //        _context.Customers.Remove(customer);
    //        await _context.SaveChangesAsync();
    //    }
    //}

    public async Task<OperationResult<bool>> DeleteCustomer(int id)
    {
        try
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return OperationResultWrapper.Success(true, "customery jnjvec");
            }
            else
            {
                return OperationResultWrapper.Failure<bool>("customery chi gtnvel");
            }
        }
        catch (Exception ex)
        {
            return OperationResultWrapper.Failure<bool>($"error jnjelu jamanak :{ex.Message}");
        }
    }

    //public async Task<Customer> GetCustomerById(int id)
    //{
    //    var customer = await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);
    //    return customer;
    //}

    public async Task<OperationResult<Customer>> GetCustomerById(int id)
    {
        try
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);
            return customer != null
                ? OperationResultWrapper.Success(customer, "customery gtnvav")
                : OperationResultWrapper.Failure<Customer>("customery chi gtnvel");

        }
        catch (Exception ex)
        {
            return OperationResultWrapper.Failure<Customer>($"error customeri stanalu jamanak:{ex.Message}");
        }
    }


    public async Task<List<Customer>> GetCustomers()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task SaveCustomer(Customer customer)
    {
        //if (customer.Id == 0) await _context.Customers.AddAsync(customer);
        /*else*/
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }
}

namespace BlazorWithEF.Data;

public interface ICustomerService
{
    Task<List<Customer>> GetCustomers();
    Task<Customer> GetCustomerById(int id);
    Task SaveCustomer(Customer customer);
    Task DeleteCustomer(int id);
    Task AddCustomer(Customer customer);
}

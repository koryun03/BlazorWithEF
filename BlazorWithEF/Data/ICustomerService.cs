namespace BlazorWithEF.Data
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(int id);

        void SaveCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}

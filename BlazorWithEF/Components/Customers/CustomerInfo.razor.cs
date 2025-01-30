namespace BlazorWithEF.Components.Customers;

public partial class CustomerInfo
{
    //[Inject] BlazorWithEF.Data;
    [Inject] public ICustomerService _customerService { get; set; }
    [Inject] public ISnackbar snackBar { get; set; }
    private bool hover { get; set; } = true;
    private bool dense { get; set; } = false;
    private string searchSting { get; set; } = string.Empty;
    private Customer customer = new Customer();
    private List<Customer> customers = new List<Customer>();

    protected override async Task OnInitializedAsync()
    {
        GetAllCustomer();
    }

    private List<Customer> GetAllCustomer()
    {
        customers = _customerService.GetCustomers();
        return customers;
    }

    private bool Search(Customer customer)
    {
        if (customer.FirstName != null && customer.LastName != null && customer.PhoneNumber != null &&
            (customer.FirstName.Contains(searchSting, StringComparison.OrdinalIgnoreCase)) ||
             customer.LastName.Contains(searchSting, StringComparison.OrdinalIgnoreCase) ||
             customer.PhoneNumber.Contains(searchSting, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Save()
    {
        _customerService.SaveCustomer(customer);
        customer = new Customer();
        snackBar.Add("Customer Save Successfully", Severity.Success);
        GetAllCustomer();
    }

    private void Edit(int id)
    {
        customer = customers.FirstOrDefault(c => c.Id == id);
    }

    private void Delete(int id)
    {
        _customerService.DeleteCustomer(id);
        snackBar.Add("Customer Delete Successfully", Severity.Success);
        GetAllCustomer();
    }
}

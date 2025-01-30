namespace BlazorWithEF.Components.Customers;

public partial class CustomerInfo
{
    //[Inject] BlazorWithEF.Data;
    [Inject] public ICustomerService _customerService { get; set; }
    [Inject] public ISnackbar snackBar { get; set; }
    private bool hover { get; set; } = true;
    private bool dense { get; set; } = false;
    private string searchSting { get; set; } = string.Empty;
    private Customer customer { get; set; } = new();
    private List<Customer> CustomerList { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        CustomerList = await GetAllCustomer();
    }

    private async Task<List<Customer>> GetAllCustomer()
    {
        return await _customerService.GetCustomers();
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

    private async Task Save()
    {
        await _customerService.SaveCustomer(customer);
        customer = new Customer();
        snackBar.Add("Customer Save Successfully", Severity.Success);
        await GetAllCustomer();
    }

    private void Edit(int id)
    {
        customer = CustomerList.FirstOrDefault(c => c.Id == id);
    }

    private async Task Delete(int id)
    {
        await _customerService.DeleteCustomer(id);
        snackBar.Add("Customer Delete Successfully", Severity.Success);
        await GetAllCustomer();
    }
}

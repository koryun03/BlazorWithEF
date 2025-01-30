namespace BlazorWithEF.Components.Customers;

public partial class CustomerInfo
{
    //[Inject] BlazorWithEF.Data;
    [Inject] public ICustomerService _customerService { get; set; }
    [Inject] public IDialogService _dialogService { get; set; }  // ??????
    [Inject] public ISnackbar snackBar { get; set; }
    private bool hover { get; set; } = true;
    private bool dense { get; set; } = false;
    private string searchSting { get; set; } = string.Empty;
    private Customer customer { get; set; } = new();
    private List<Customer> CustomerList { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        CustomerList = await GetAllCustomer();
        StateHasChanged();   ///////?????
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

    private async void EditAsync(Customer customer)
    {
        var parameters = new DialogParameters<CustomerDialog>
        {
            {"typeDialog",2},
            {"CustomerInput",customer}
        };

        ////nayel
        //var dialog = await DialogService.ShowAsync<CustomerDialog>(
        //  "customeri datai popoxutyun",
        //  parameters: parameters,
        //  new DialogOptions()
        //  {
        //      CloseButton = true,
        //      MaxWidth = MaxWidth.Small,
        //      FullWidth = true,
        //  });
        //var res = await z.Result;

        var z = await _dialogService.ShowAsync<CustomerDialog>(
          "customeri datai popoxutyun",
          parameters: parameters,
          new DialogOptions()
          {
              CloseButton = true,
              MaxWidth = MaxWidth.Small,
              FullWidth = true,
          });

        var res = await z.Result;

        if (res.Canceled)
        {
            return;
        }

        //await GetAllCustomer();
        await OnInitializedAsync();
    }

    private async Task DeleteAsync(int id)
    {
        await _customerService.DeleteCustomer(id);
        snackBar.Add("Customer Delete Successfully", Severity.Success);
        //await GetAllCustomer();
        await OnInitializedAsync();
    }

    private async Task ButtonAddClickAsync()
    {
        var parameters = new DialogParameters<CustomerDialog>
        {
            {"typeDialog",1},
        };

        ////nayel
        //var dialog = await DialogService.ShowAsync<CustomerDialog>(
        //  "customeri datai popoxutyun",
        //  parameters: parameters,
        //  new DialogOptions()
        //  {
        //      CloseButton = true,
        //      MaxWidth = MaxWidth.Small,
        //      FullWidth = true,
        //  });
        //var res = await z.Result;


        var z = await _dialogService.ShowAsync<CustomerDialog>(
            "customeri avelacum",
            parameters: parameters,
            new DialogOptions()
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Small,
                FullWidth = true,
            });

        var res = await z.Result;

        if (res.Canceled)
        {
            return;
        }

        //await GetAllCustomer();
        await OnInitializedAsync();
    }
}

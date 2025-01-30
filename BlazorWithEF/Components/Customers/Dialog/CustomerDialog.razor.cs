namespace BlazorWithEF.Components.Customers.Dialog;

public partial class CustomerDialog
{
    [CascadingParameter] public IMudDialogInstance MudDialog { get; set; }
    [Parameter] public int TypeDialog { get; set; }
    [Parameter] public Customer CustomerInput { get; set; }
    [Inject] private ISnackbar Snackbar { get; set; }
    [Inject] private ICustomerService _customerService { get; set; }
    private Customer Customer { get; set; } = new();

    private string LabelButton { get; set; }

    protected override async Task OnInitializedAsync()
    {
        LabelButton = TypeDialog == 1 ? "Avelacnel" : "Savee";
        if (TypeDialog == 2) //ete 1 a uremn avelacnelu operationa
        {
            Customer = CustomerInput;
        }
        await Task.CompletedTask;
    }

    private async Task ActionButtonAsync(Customer customer)
    {
        if (TypeDialog == 1)
        {
            //await AddCustomerAsync();
            await AddCustomerAsync(customer);
        }
        else
        {
            await EditCustomerAsync(customer);
        }
        MudDialog.Close(DialogResult.Ok(true));
    }

    private async Task AddCustomerAsync(Customer customer)
    {
        await _customerService.AddCustomer(customer);
        Snackbar.Add("Customery poxvav", Severity.Success);
        //await GetAllCustomer();
    }

    private async Task EditCustomerAsync(Customer customer)
    {
        await _customerService.SaveCustomer(Customer);
        Snackbar.Add("Customery poxvav", Severity.Success);
    }
}

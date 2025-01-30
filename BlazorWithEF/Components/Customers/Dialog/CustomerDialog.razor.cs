
namespace BlazorWithEF.Components.Customers.Dialog
{
    public partial class CustomerDialog
    {
        [CascadingParameter] private IMudDialogInstance MudDialog { get; set; }
        [Parameter] public int TypeDialog { get; set; }
        [Parameter] public Customer Customer { get; set; }
        [Parameter] private ISnackbar Snackbar { get; set; }
        private string LabelButton { get; set; }
        protected override async Task OnInitializedAsync()
        {
            LabelButton = TypeDialog == 1 ? "Avelacnel" : "Savee";
        }
    }
}

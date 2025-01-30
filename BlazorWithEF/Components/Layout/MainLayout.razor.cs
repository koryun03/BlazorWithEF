namespace BlazorWithEF.Components.Layout;

public partial class MainLayout
{
    public MudTheme Theme = new()
    {
        ZIndex = new()
        {
            Dialog = 500
        }
    };

    private bool DrawerOpen { get; set; }
    private bool IsDarkMode { get; set; } = false;
    private string? Icon { get; set; } = Icons.Material.Filled.Brightness5;
    private string? VisibleLogin { get; set; }
    private bool Dense { get; set; } = true;
    private Breakpoint Breakpoint { get; set; } = Breakpoint.Sm;
    private DrawerClipMode ClipMode { get; set; } = DrawerClipMode.Always;

    public void DrawerToggle()
    {
        DrawerOpen = !DrawerOpen;
    }

    private void ToggleTheme()
    {
        IsDarkMode = !DrawerOpen;
        Icon = IsDarkMode ? Icons.Material.Filled.Brightness5 : Icons.Material.Filled.Brightness4;
    }

    protected override void OnInitialized()
    {
        var login = Environment.UserName;
        VisibleLogin = string.Concat(login[0], login.Last()).ToUpper();
    }
}

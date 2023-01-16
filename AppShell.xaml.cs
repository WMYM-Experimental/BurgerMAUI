namespace WashingtonYandun_Hamburguesas;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        
        Routing.RegisterRoute(nameof(
            Views.BurgerItemPage_wy),
            typeof(Views.BurgerItemPage_wy)
            );
        
        Routing.RegisterRoute(
            nameof(Views.BurgerListPage_wy),
            typeof(Views.BurgerListPage_wy)
            );
    }
}

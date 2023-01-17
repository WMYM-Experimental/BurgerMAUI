using WashingtonYandun_Hamburguesas.Views;

namespace WashingtonYandun_Hamburguesas;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        
        Routing.RegisterRoute(
            nameof(BurgerListPage_wy),
            typeof(BurgerListPage_wy)
            );

        Routing.RegisterRoute(
            nameof(BurgerItemPage_wy),
            typeof(BurgerItemPage_wy)
            );
        
    }
}

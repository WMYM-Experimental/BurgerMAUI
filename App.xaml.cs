using WashingtonYandun_Hamburguesas.Data;

namespace WashingtonYandun_Hamburguesas;

public partial class App : Application
{
    public static BurgerDatabase_wy Repository_wy { get; private set; }
    public App(BurgerDatabase_wy repo)
	{
		InitializeComponent();

		MainPage = new AppShell();
		Repository_wy = repo;
    }
}

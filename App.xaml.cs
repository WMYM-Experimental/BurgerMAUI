using WashingtonYandun_Hamburguesas.Data;

namespace WashingtonYandun_Hamburguesas;

public partial class App : Application
{
	public static BurgerDatabase BurgerRepo { get; set; }
	public App(BurgerDatabase repo)
	{
		InitializeComponent();

		MainPage = new AppShell();
		BurgerRepo = repo;
    }
}

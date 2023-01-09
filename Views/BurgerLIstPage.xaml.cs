using WashingtonYandun_Hamburguesas.Models;

namespace WashingtonYandun_Hamburguesas.Views;

public partial class BurgerLIstPage : ContentPage
{
	public BurgerLIstPage()
	{
        InitializeComponent();
        List<Burger> burger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = burger;

    }

    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(BurgerItemPage));
    }
}
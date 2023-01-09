using WashingtonYandun_Hamburguesas.Models;
using WashingtonYandun_Hamburguesas.Data;

namespace WashingtonYandun_Hamburguesas.Views;

public partial class BurgerItemPage : ContentPage
{
    Burger Item = new Burger();
    bool _flag;

    public BurgerItemPage()
    {
        InitializeComponent();
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        Item.Name = name_wy.Text;
        Item.Description = desc_wy.Text;
        Item.WithExtraCheese = _flag;
        App.BurgerRepo.AddNewBurger(Item);
        Shell.Current.GoToAsync(nameof(BurgerLIstPage));
    }
    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(BurgerLIstPage));
    }
    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _flag = e.Value;
    }
}
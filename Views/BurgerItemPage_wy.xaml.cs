using WashingtonYandun_Hamburguesas.Models;

namespace WashingtonYandun_Hamburguesas.Views;


[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class BurgerItemPage_wy : ContentPage
{

    Burger_wy CurrentBurger = new();
    Burger_wy aux = new();
    private bool _flag;

    public int ItemId
    {
        set { GetCurrentBurger(value); }
    }

    public BurgerItemPage_wy()
    {
        InitializeComponent();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (BindingContext == null)
        {
            CurrentBurger.Name_wy = nombre_wy.Text;
            CurrentBurger.Description_wy = desc_wy.Text;
            CurrentBurger.WithExtraCheese_wy = _flag;

            int error = App.Repository_wy.AddNewBurger(CurrentBurger);
            if (error == 404)
            {
                await DisplayAlert(
                    "Alert",
                    "Burger already exist",
                    "OK");
            }
            else
            {
                await Shell.Current.GoToAsync(
                    nameof(BurgerListPage_wy)
                    );
            }

        }
        else
        {
            App.Repository_wy.UpdateBurger(
                aux.Id,
                aux.Name_wy,
                aux.Description_wy,
                aux.WithExtraCheese_wy
                );
            await Shell.Current.GoToAsync(
                nameof(BurgerListPage_wy)
                );
        }
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(
            nameof(BurgerListPage_wy)
            );
        return;
    }

    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _flag = e.Value;
        return;
    }

    private void GetCurrentBurger(int Id)
    {
        Burger_wy searchedBurger_wy = new();
        searchedBurger_wy = App.Repository_wy.GetBurgerById(Id);
        aux = searchedBurger_wy;
        BindingContext = searchedBurger_wy;
    }

    private async void DeleteBurgerDB(object sender, EventArgs e)
    {
        App.Repository_wy.DeleteBurger(aux.Id);
        await Shell.Current.GoToAsync(
            nameof(BurgerListPage_wy)
            );
    }

    private async void ReturnTo(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(
            nameof(BurgerListPage_wy)
            );
    }

}
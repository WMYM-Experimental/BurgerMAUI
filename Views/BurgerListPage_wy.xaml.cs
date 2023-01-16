using WashingtonYandun_Hamburguesas.Models;

namespace WashingtonYandun_Hamburguesas.Views;

public partial class BurgerListPage_wy : ContentPage
{

    bool searched = false;

    public BurgerListPage_wy()
    {
        InitializeComponent();
        List<Burger_wy> burger = App.Repository_wy.GetAllBurgers();
        listBurgers_wy.ItemsSource = burger;
        if (!burger.Any())
        {
            msg_wy.IsVisible = true;
        }
        else
        {
            msg_wy.IsVisible = false;
        }
    }

    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(BurgerItemPage_wy));
    }

    public void SearchBurger(object sender, EventArgs e)
    {
        List<Burger_wy> burger = App.Repository_wy.GetBurgersByName(search_wy.Text);
        listBurgers_wy.ItemsSource = burger;
        if (!burger.Any())
        {
            msg_wy.IsVisible = true;
        }
        else
        {
            msg_wy.IsVisible = false;
        }
        searched = true;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        List<Burger_wy> burger = App.Repository_wy.GetAllBurgers();
        listBurgers_wy.ItemsSource = burger;
        if (!burger.Any())
        {
            msg_wy.IsVisible = true;
        }
        else
        {
            msg_wy.IsVisible = false;
        }
    }

    private void ChangeCurrentText(object sender, TextChangedEventArgs e)
    {
        var newText = e.NewTextValue;
        if (string.IsNullOrWhiteSpace(newText))
        {
            btnDelete_wy.IsEnabled = false;
            btnDelete_wy.IsVisible = false;

            if (searched)
            {
                searched = false;
                List<Burger_wy> burger = App.Repository_wy.GetAllBurgers();
                listBurgers_wy.ItemsSource = burger;
                if (!burger.Any())
                {
                    msg_wy.IsVisible = true;
                }
                else
                {
                    msg_wy.IsVisible = false;
                }
            }
        }
        else
        {
            btnDelete_wy.IsEnabled = true;
            btnDelete_wy.IsVisible = true;
            
            if (searched)
            {
                List<Burger_wy> burger = App.Repository_wy.GetBurgersByName(search_wy.Text);
                listBurgers_wy.ItemsSource = burger;
                if (!burger.Any())
                {
                    msg_wy.IsVisible = true;
                }
                else
                {
                    msg_wy.IsVisible = false;
                }
            }
        }
    }


    private async void Selection(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            Burger_wy burger = (Burger_wy)e.CurrentSelection[0];
            await Shell.Current.GoToAsync(
                $"{nameof(BurgerItemPage_wy)}?{nameof(BurgerItemPage_wy.ItemId)}={burger.Id}"
                );

            listBurgers_wy.SelectedItem = null;
        }
    }

    private void ClearEntry(object sender, EventArgs e)
    {
        search_wy.Text = "";
    }

    private async void SetEmptyList(object sender, EventArgs e)
    {
        bool res = await DisplayAlert(
            "Alert",
            "Empty list?",
            "No",
            "Yes");
        
        if (!res)
        {
            App.Repository_wy.EmptyList();
            List<Burger_wy> burger = App.Repository_wy.GetAllBurgers();
            listBurgers_wy.ItemsSource = burger;
            if (!burger.Any())
            {
                msg_wy.IsVisible = true;
            }
            else
            {
                msg_wy.IsVisible = false;
            }
        }
        return;
    }

    private void OnPressed(object sender, EventArgs e)
    {
        btnAdd_wy.BackgroundColor = Color.FromArgb("#FF0000");
    }

    private void OnReleased(object sender, EventArgs e)
    {
        btnAdd_wy.BackgroundColor = Color.FromArgb("#FFFFFF");
    }
}
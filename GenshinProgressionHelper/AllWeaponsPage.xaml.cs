using GenshinProgressionHelper.ViewModels;

namespace GenshinProgressionHelper;

public partial class AllWeaponsPage : ContentPage
{
    public AllWeaponsPage()
    {
        InitializeComponent();
        this.BindingContext = new WeaponList();
    }

    private async void ShowWeaponDetails_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var weapon = button.BindingContext as Weapon;
        if (weapon != null)
        {
            await Navigation.PushAsync(new WeaponDetailsPage(weapon));
        }
    }
}
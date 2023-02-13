using GenshinProgressionHelper.ViewModels;

namespace GenshinProgressionHelper;

public partial class WeaponSelectionPage : ContentPage
{
	private UserEntry entry;
    private EquipableWeaponsList viewModel;

    public WeaponSelectionPage(UserEntry _entry)
	{
		InitializeComponent();
		entry = _entry;
		viewModel = new EquipableWeaponsList();
        viewModel.RemoveNoViableWeapons(entry.CharacterName);
        this.BindingContext = viewModel;
        this.EquipableWeaponsList.ItemsSource = viewModel.EquipableWeapons;
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }

    private async void ChangeWeapon_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var weapon = button.BindingContext as Weapon;
        entry.WeapponName = weapon.Name;
        App.UserDatabase.Update(entry);
        MyCharactersPage.entryWasChanged = true;
        await Navigation.PopAsync();
    }
}
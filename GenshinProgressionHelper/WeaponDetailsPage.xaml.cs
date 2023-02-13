namespace GenshinProgressionHelper;

public partial class WeaponDetailsPage : ContentPage
{
	private Weapon weapon;
	public WeaponDetailsPage(Weapon _weapon)
	{
		InitializeComponent();
		weapon= _weapon;
		this.BindingContext = weapon;
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}
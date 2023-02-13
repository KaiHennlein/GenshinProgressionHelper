namespace GenshinProgressionHelper;

public partial class CharacterDetailsPage : ContentPage
{
	private Character character;
	public CharacterDetailsPage(Character _character)
	{
		InitializeComponent();
		character = _character;
		this.BindingContext = character;
	}
}
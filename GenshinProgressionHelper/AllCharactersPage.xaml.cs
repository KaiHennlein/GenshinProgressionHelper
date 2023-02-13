using GenshinProgressionHelper.ViewModels;

namespace GenshinProgressionHelper;

public partial class AllCharactersPage : ContentPage
{
    public AllCharactersPage()
	{
		InitializeComponent();
        this.BindingContext = new CharacterList();
    }

    private async void AddEntry_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        Character character;
        character = button.BindingContext as Character;

        /*
        if (DeviceInfo.Current.Platform == DevicePlatform.Android || DeviceInfo.Current.Platform == DevicePlatform.iOS)
        {
            Grid grid = button.Parent as Grid;
            var list = grid.Children;
            Label label = list.FirstOrDefault() as Label;
            string characterName = label.Text;
            character = App.CharacterDatabase.GetCharacterByName(characterName);
        }
        else
        {
            character = button.BindingContext as Character;
        }
        */
        
        if (character != null)
        {
            if (!Functions.DoesEntryAlreadyExist(character.Name))
            {
                UserEntry entry = new UserEntry
                {
                    CharacterName = character.Name,
                    WeapponName = "No Weapon Selected",
                    LastFarmingDate = DateTime.Now
                };

                App.UserDatabase.Add(entry);
                MyCharactersPage.entryWasChanged = true;
                MainPage.entryWasChanged = true;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Reminder", "This Character is already in your list.", "OK");
            }
        }
    }

    private async void ShowCharacterDetails_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var character = button.BindingContext as Character;
        if (character != null)
        {
            await Navigation.PushAsync(new CharacterDetailsPage(character));
        }
    }
}
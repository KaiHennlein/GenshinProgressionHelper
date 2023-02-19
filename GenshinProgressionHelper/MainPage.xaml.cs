using GenshinProgressionHelper.ViewModels;

namespace GenshinProgressionHelper;

public partial class MainPage : ContentPage
{
    private Recommandations viewModel;
    public static bool entryWasChanged = false;
    private static bool placeHolderIsActive = false;
    private Label placeHolder = new Label();

    public MainPage()
	{
        InitializeComponent();
        viewModel = new Recommandations();
        this.BindingContext = viewModel;
        this.CharacterTalentDomainList.ItemsSource = viewModel.CharactersWithDomainsAvailable;
        this.WeaponDomainList.ItemsSource = viewModel.WeaponsWithDomainsAvailable;
        this.RespawnedCharacterMaterialsList.ItemsSource = viewModel.CharactersWithRespawnedMaterials;
        ChangeVisibility();
        AddPlaceHolder();
        //Hiding Debug menu
        bool available = false;
        this.DebugMenu.IsEnabled = available;
        this.DebugMenu.IsVisible = available;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DebugMenuPage());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        //Updates the list if it was changed from another page
        if (entryWasChanged)
        {
            viewModel.UpdateRecommendations();
            entryWasChanged = false;
            ChangeVisibility();
            AddPlaceHolder();
            RemovePlaceHolder();
        }
    }

    private void UpdateLastFarmingDate_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;

        //Only works in Windows
        /*
        
        Character character = button.BindingContext as Character;

        if (character != null)
        {
            string characterName = character.Name;
            UserEntry entry = App.UserDatabase.GetByCharacterName(characterName);
            if (entry != null)
            {
                entry.LastFarmingDate = DateTime.Now;
                App.UserDatabase.Update(entry);
                viewModel.UpdateRecommendations();
                ChangeVisibility();
            }
        }
        */

        //Fix to work with Android
        VerticalStackLayout verticalStackLayout = button.Parent as VerticalStackLayout;
        if (verticalStackLayout != null)
        {
            List<IView> listOfChilden = verticalStackLayout.Children.ToList();
            Label label = listOfChilden.FirstOrDefault() as Label;
            if (label != null)
            {
                string characterName = label.Text;
                var entry = App.UserDatabase.GetByCharacterName(characterName);
                if (entry != null)
                {
                    entry.LastFarmingDate = DateTime.Now;
                    App.UserDatabase.Update(entry);
                    viewModel.UpdateRecommendations();
                    ChangeVisibility();
                }
            }
        }
    }

    private void AddPlaceHolder()
    {  
        //Adds a placholder if no material is available or if no character is selected
        if (viewModel.CharactersWithDomainsAvailable.Count == 0 && viewModel.CharactersWithRespawnedMaterials.Count == 0 && viewModel.WeaponsWithDomainsAvailable.Count == 0)
        {
            placeHolder.FontSize = 20;
            placeHolder.FontAttributes = FontAttributes.Bold;
            placeHolder.HorizontalTextAlignment = TextAlignment.Center;
            placeHolder.Padding = 10;
            placeHolder.Text = "No materials available today";
            this.AvailabilityList.Add(placeHolder);
            placeHolderIsActive = true;
        }
        else if (App.UserDatabase.GetAllEntries().Count == 0)
        {
            placeHolder.FontSize = 20;
            placeHolder.FontAttributes = FontAttributes.Bold;
            placeHolder.HorizontalTextAlignment = TextAlignment.Center;
            placeHolder.Padding = 10;
            placeHolder.Text = "No characters added to your list";
            this.AvailabilityList.Add(placeHolder);
            placeHolderIsActive = true;
        }
    }

    private void RemovePlaceHolder()
    {
        if (placeHolderIsActive)
        {
            if (viewModel.CharactersWithDomainsAvailable.Count != 0 && viewModel.CharactersWithRespawnedMaterials.Count != 0 && viewModel.WeaponsWithDomainsAvailable.Count != 0)
            {
                this.AvailabilityList.Remove(placeHolder);
            } 
            else if (App.UserDatabase.GetAllEntries().Count != 0)
            {
                this.AvailabilityList.Remove(placeHolder);
            }
        }
    }

    private void ChangeVisibility()
    {
        //Change visibility depending on availability
        if (viewModel.CharactersWithDomainsAvailable.Count == 0)
        {
            this.CharacterTalentDomainLabel.IsVisible = false;
            this.CharacterTalentDomainLabel.IsEnabled = false;
            this.CharacterTalentDomainList.IsVisible = false;
            this.CharacterTalentDomainList.IsEnabled = false;
        }
        else
        {
            this.CharacterTalentDomainLabel.IsVisible = true;
            this.CharacterTalentDomainLabel.IsEnabled = true;
            this.CharacterTalentDomainList.IsVisible = true;
            this.CharacterTalentDomainList.IsEnabled = true;
        }

        if (viewModel.CharactersWithRespawnedMaterials.Count == 0)
        {
            this.RespawnedCharacterMaterialsLabel.IsVisible = false;
            this.RespawnedCharacterMaterialsLabel.IsEnabled = false;
            this.RespawnedCharacterMaterialsList.IsVisible = false;
            this.RespawnedCharacterMaterialsList.IsEnabled = false;
        }
        else
        {
            this.RespawnedCharacterMaterialsLabel.IsVisible = true;
            this.RespawnedCharacterMaterialsLabel.IsEnabled = true;
            this.RespawnedCharacterMaterialsList.IsVisible = true;
            this.RespawnedCharacterMaterialsList.IsEnabled = true;
        }

        if (viewModel.WeaponsWithDomainsAvailable.Count == 0)
        {
            this.WeaponDomainLabel.IsVisible = false;
            this.WeaponDomainLabel.IsEnabled = false;
            this.WeaponDomainList.IsVisible = false;
            this.WeaponDomainList.IsEnabled = false;
        }
        else
        {
            this.WeaponDomainLabel.IsVisible = true;
            this.WeaponDomainLabel.IsEnabled = true;
            this.WeaponDomainList.IsVisible = true;
            this.WeaponDomainList.IsEnabled = true;
        }
    }
}


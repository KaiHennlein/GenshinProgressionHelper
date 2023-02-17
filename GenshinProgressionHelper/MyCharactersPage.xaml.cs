using GenshinProgressionHelper.ViewModels;
using System.Collections.ObjectModel;

namespace GenshinProgressionHelper;

public partial class MyCharactersPage : ContentPage
{
    private UserEntries viewModel;
    public static bool entryWasChanged = false;
    private static bool placeHolderIsActive = false;
    private Label placeHolder = new Label();

    public MyCharactersPage()
	{
		InitializeComponent();
        viewModel = new UserEntries();
        this.BindingContext = viewModel;
        this.EntryList.ItemsSource = viewModel.Entries;
        AddPlaceHolder();
    }

    private async void DeleteEntry_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Delete Character", "Do you want to delet this character from your list?", "Yes", "No");
        if (answer)
        {
            var button = sender as Button;

            /*
            var listView = this.FindByName<ListView>("EntryList");
            ObservableCollection<UserEntry> userEntries = listView.ItemsSource as ObservableCollection<UserEntry>;
            
            var context = button.BindingContext as UserEntry;

            if (userEntries != null)
            {
                if (context != null)
                {
                    userEntries.Remove(context);
                    App.UserDatabase.Delete(context.Id);
                }
            }
            */

            VerticalStackLayout verticalStackLayout = button.Parent as VerticalStackLayout;
            if (verticalStackLayout != null)
            {
                List<IView> listOfChilden = verticalStackLayout.Children.ToList();
                Label label = listOfChilden.FirstOrDefault() as Label;
                if (label != null)
                {
                    string characterName = label.Text.Remove(0, 8);
                    var entry = App.UserDatabase.GetByCharacterName(characterName);
                    if (entry != null)
                    {
                        //userEntries.Remove(entry);
                        App.UserDatabase.Delete(entry.Id);
                        viewModel.UpdateEntries();
                    }
                }
            }
        }
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (entryWasChanged)
        {
            viewModel.UpdateEntries();
            entryWasChanged = false;
            RemovePlaceHolder();
        }
    }

    private async void ChangeWeapon_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        
        HorizontalStackLayout horizontalStackLayout = button.Parent as HorizontalStackLayout;
        if (horizontalStackLayout != null)
        {
            VerticalStackLayout verticalStackLayout = horizontalStackLayout.Parent as VerticalStackLayout;
            if (verticalStackLayout != null)
            {
                List<IView> listOfChilden = verticalStackLayout.Children.ToList();
                Label label = listOfChilden.FirstOrDefault() as Label;
                if (label != null)
                {
                    string characterName = label.Text.Remove(0, 8);
                    var entry = App.UserDatabase.GetByCharacterName(characterName);
                    if (entry != null)
                    {
                        await Navigation.PushAsync(new WeaponSelectionPage(entry));
                    }
                }
            }
        }
        
        //Only works on Windows
        //var entry = button.BindingContext as UserEntry;
        //await Navigation.PushAsync(new WeaponSelectionPage(entry));
    }

    private void AddPlaceHolder()
    {
        if (App.UserDatabase.GetAllEntries().Count == 0)
        {
            placeHolder.FontSize = 20;
            placeHolder.FontAttributes = FontAttributes.Bold;
            placeHolder.HorizontalTextAlignment = TextAlignment.Center;
            placeHolder.Padding = 10;
            placeHolder.Text = "No characters added to your list";
            this.StackLayout.Add(placeHolder);
            placeHolderIsActive = true;
        }
    }

    private void RemovePlaceHolder()
    {
        if (placeHolderIsActive)
        {
            if (App.UserDatabase.GetAllEntries().Count != 0)
            {
                this.StackLayout.Remove(placeHolder);
            }
        }
    }
}
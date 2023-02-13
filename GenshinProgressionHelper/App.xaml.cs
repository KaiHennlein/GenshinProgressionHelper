namespace GenshinProgressionHelper;

public partial class App : Application
{
	public static UserDatabase UserDatabase { get; private set; }
	public static CharacterDatabase CharacterDatabase { get; private set; }
	public static WeaponDatabase WeaponDatabase { get; private set; }

	public App(UserDatabase userDatabase, CharacterDatabase characterDatabase, WeaponDatabase weaponDatabase)
	{
		InitializeComponent();

		MainPage = new AppShell();

		UserDatabase = userDatabase;
		CharacterDatabase = characterDatabase;
		WeaponDatabase = weaponDatabase;
    }
}

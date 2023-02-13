namespace GenshinProgressionHelper;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		string dbPathUserEntries = Path.Combine(FileSystem.AppDataDirectory, "userEntries.db");
		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<UserDatabase>(s, dbPathUserEntries));

		string dbPathCharacters = Path.Combine(FileSystem.AppDataDirectory, "characters.db");
		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<CharacterDatabase>(s, dbPathCharacters));

		string dbPathWeapons = Path.Combine(FileSystem.AppDataDirectory, "weapons.db");
		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<WeaponDatabase>(s, dbPathWeapons));

        Functions.CheckDatabaseForUpdates(dbPathCharacters, dbPathWeapons);

		return builder.Build();
	}
}

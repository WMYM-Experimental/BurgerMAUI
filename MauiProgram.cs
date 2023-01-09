using WashingtonYandun_Hamburguesas.Data;

namespace WashingtonYandun_Hamburguesas;

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

        static string GetLocalFilePath(string filename)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }

        string dbPath = GetLocalFilePath("burger.db3");
        builder.Services.AddSingleton<BurgerDatabase>(
			s => ActivatorUtilities.CreateInstance<BurgerDatabase>(s, dbPath)
			);
        return builder.Build();
	}
}

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

        string dbPath = FileAccessHelper.GetLocalFilePath("burger.db3");
        builder.Services.AddSingleton<BurgerDatabase_wy>(s => ActivatorUtilities.CreateInstance<BurgerDatabase_wy>(s, dbPath));
		
        return builder.Build();
	}
}

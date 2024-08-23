using IODDFinder.Services;
using IODDFinder.ViewModels;
using IODDFinder.Views;
using Microsoft.Extensions.Logging;

namespace IODDFinder;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .RegisterServices()
            .RegisterViewModels()
            .RegisterViews()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
        //mauiAppBuilder.Services.AddTransient<ILoggingService, LoggingService>();
        //mauiAppBuilder.Services.AddTransient<ISettingsService, SettingsService>();
        mauiAppBuilder.Services.AddTransient<APIService>();

        // More services registered here.

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<MainViewModel>();
        mauiAppBuilder.Services.AddTransient<ProductsViewModel>();
        mauiAppBuilder.Services.AddTransient<ProductDetailsViewModel>();

        // More view-models registered here.

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<MainView>();
        mauiAppBuilder.Services.AddTransient<ProductsView>();
        mauiAppBuilder.Services.AddTransient<ProductDetailsView>();

        // More views registered here.

        return mauiAppBuilder;
    }
}


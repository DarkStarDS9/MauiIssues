using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Xaml.Diagnostics;

namespace MauiIssues;

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
		
		ConfigureServices(builder.Services);

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
	
	private static void ConfigureServices(IServiceCollection services)
	{
		services.AddSingleton<ILogger<BindingDiagnostics>, BindingDiagnosticsLogger>();
		services.AddTransient<Issue22078>();
		services.AddTransient<Issue22078ViewModel>();
	}
}
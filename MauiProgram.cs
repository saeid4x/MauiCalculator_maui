using Microsoft.Extensions.Logging;

namespace CalculatorDemo2
{
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
                    fonts.AddFont("fontello.ttf", "Fontello");
                    fonts.AddFont("Kalameh-SemiBold.ttf", "kalameh_semibold");
                    fonts.AddFont("Manshoor-ExtraBold.ttf", "manshoor_extrabold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

using Microsoft.Extensions.Logging;
using News.ViewModels;
using News.Views;

namespace News;
public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder();
    builder
      .UseMauiApp<App>()
      .ConfigureFonts( fonts =>
      {
        fonts.AddFont( "FontAwesome.otf", "FontAwesome" );
        fonts.AddFont( "OpenSans-Regular.ttf", "OpenSansRegular" );
        fonts.AddFont( "OpenSans-Semibold.ttf", "OpenSansSemibold" );
      } );

#if DEBUG
		builder.Logging.AddDebug();
#endif

    return builder.Build();
  }

  public static MauiAppBuilder RegisterAppTypes(this MauiAppBuilder builder )
  {
    //ViewModels
    builder.Services.AddTransient<HeadlinesViewModel>();

    //Views
    builder.Services.AddTransient<AboutView>();
    builder.Services.AddTransient<HeadlinesView>();
    builder.Services.AddTransient<ArticleView>();

    return builder;
  }
}

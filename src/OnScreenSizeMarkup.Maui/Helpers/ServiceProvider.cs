#if NET9_0_OR_GREATER
	using Microsoft.Extensions.DependencyInjection;
#endif
namespace OnScreenSizeMarkup.Maui.Helpers;


static class ServiceProvider
{
	internal static TService GetService<TService>() => Current.GetService<TService>()!;

	static IServiceProvider Current
	{
		get
		{
			#if NET9_0_OR_GREATER
				return IPlatformApplication.Current?.Services ?? null!;
			#else 
				#if ANDROID
				    return MauiApplication.Current.Services;
				#elif IOS || MACCATALYST
				    return MauiUIApplicationDelegate.Current.Services;
				#else
					return null!;
				#endif
			#endif
		}
		
	}
}
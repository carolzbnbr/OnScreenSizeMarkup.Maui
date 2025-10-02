using System.Diagnostics.CodeAnalysis;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace OnScreenSizeMarkup.Maui.PlatformDensities;

[SuppressMessage("Style", "IDE0040:Adicionar modificadores de acessibilidade")]
static partial class ScreenDensityPlatform
{
	public static partial (double xdpi, double ydpi) GetPixelPerInches()
	{
		var displayMetrics = Android.App.Application.Context.Resources?.DisplayMetrics;

		return (displayMetrics?.Xdpi ?? 0, displayMetrics?.Ydpi ?? 0);
	}

	public static partial (double width, double height) GetNativeScreenResolution()
	{
		var windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
		if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.R)
		{
			var displaySize = windowManager!.CurrentWindowMetrics.Bounds;
			return (displaySize.Width(), displaySize.Height());
		}
		else
		{
			var displayMetrics = new DisplayMetrics();
			windowManager!.DefaultDisplay!.GetMetrics(displayMetrics);
			return (displayMetrics.WidthPixels, displayMetrics.HeightPixels);
		}
	}
}

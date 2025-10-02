using UIKit;

namespace OnScreenSizeMarkup.Maui.PlatformDensities;

static partial class ScreenDensityPlatform
{
	public static partial (double xdpi, double ydpi) GetPixelPerInches()
	{
		var displayInfo = Microsoft.Maui.Devices.DeviceDisplay.Current.MainDisplayInfo;

		var scale = displayInfo.Density;
		var dpi = scale * 160;

		if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
		{
			dpi = scale * 132;
		}
		else if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
		{
			dpi = scale * 163;
		}

		return (dpi, dpi);
	}

	public static partial (double width, double height) GetNativeScreenResolution()
	{
		return (UIScreen.MainScreen.NativeBounds.Width, UIScreen.MainScreen.NativeBounds.Height);
	}
}

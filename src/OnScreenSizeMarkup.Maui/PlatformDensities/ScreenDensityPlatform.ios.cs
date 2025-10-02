using UIKit;
using CoreGraphics;
#pragma warning disable CS8603

namespace OnScreenSizeMarkup.Maui.PlatformDensities;


static partial class ScreenDensityPlatform
{
	public static partial (double xdpi, double ydpi) GetPixelPerInches()
	{
		var displayInfo = DeviceDisplay.Current.MainDisplayInfo;

		var dimensions = (displayInfo.Width / displayInfo.Density, displayInfo.Height / displayInfo.Density);

		AppleScreenDensityHelper.TryGetPpiWithFallBacks(DeviceInfo.Current.Model, DeviceInfo.Current.Name, dimensions, out var ppi);
		return (ppi, ppi);
	}

	public static partial (double width, double height) GetNativeScreenResolution()
	{
		return (UIScreen.MainScreen.NativeBounds.Width, UIScreen.MainScreen.NativeBounds.Height);
	}
}

public static class CGSizeExtensions
{
	public static double DiagonalInInches(this CGSize size, double widthInInches, double heightInInches)
	{
		return Math.Sqrt(Math.Pow(size.Width / widthInInches, 2) + Math.Pow(size.Height / heightInInches, 2));
	}
}

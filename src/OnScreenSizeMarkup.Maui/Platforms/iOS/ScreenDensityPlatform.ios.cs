#if IOS
using OnScreenSizeMarkup.Maui.Extensions;
using OnScreenSizeMarkup.Maui.Helpers;
using Microsoft.Maui.Platform;


using UIKit;
using AVFoundation;
using CoreMedia;
using MediaPlayer;
using CoreGraphics;
// ReSharper disable All
#pragma warning disable CS8603
#pragma warning disable IDE0040

namespace OnScreenSizeMarkup.Maui.PlatformDensities;

internal static partial  class ScreenDensityPlatform 
{
	public static partial (double xdpi, double ydpi) GetPixelPerInches()
	{

		var BoundsWidth = UIScreen.MainScreen.Bounds.Width;
		var NativeBoundsWidth = UIScreen.MainScreen.NativeBounds.Width;
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

#endif
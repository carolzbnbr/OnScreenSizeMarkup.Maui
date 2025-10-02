namespace OnScreenSizeMarkup.Maui.PlatformDensities;

static partial class ScreenDensityPlatform
{
	public static partial (double xdpi, double ydpi) GetPixelPerInches();

	public static partial (double width, double height) GetNativeScreenResolution();
}
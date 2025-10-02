using System.Diagnostics.CodeAnalysis;

namespace OnScreenSizeMarkup.Maui.PlatformDensities;


#if !(IOS || ANDROID || MACCATALYST || WINDOWS)
[SuppressMessage("Style", "IDE0040:Adicionar modificadores de acessibilidade")]
static partial class ScreenDensityPlatform
{
	public static partial (double xdpi, double ydpi) GetPixelPerInches()
	{
		throw new NotSupportedException("Platform implementation not found");
	}

	public static partial (double width, double height) GetNativeScreenResolution()
	{
		throw new NotSupportedException("Platform implementation not found");
	}
}
#endif

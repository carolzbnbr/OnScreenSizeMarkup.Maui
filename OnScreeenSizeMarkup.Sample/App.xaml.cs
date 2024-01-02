using OnScreenSizeMarkup.Maui;
using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Mappings;

namespace OnScreeenSizeMarkup.Sample;

public partial class App : Application
{
    public App()
    {
        Manager.Current.LogLevel = LogLevels.Verbose;
        Manager.Current.IsLogEnabled = true;
        Manager.Current.UseNativeScreenResolution = true;
        Manager.Current.Mappings = DefaultMappings.MobileMappings;
        InitializeComponent();

        MainPage = new AppShell();
    }
}
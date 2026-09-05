
namespace SampleApp;

public partial class App : Application
{
    public App()
    {
        // Manager.Current.LogLevel = LogLevels.Verbose;
        // Manager.Current.IsLogEnabled = true;
        // Manager.Current.UseNativeScreenResolution = true;

        InitializeComponent();
        
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}
# OnScreenSizeMarkup.Maui

## Purpose of the library
This library allows for the classification of diagonal screen sizes of mobile devices into a range of predefined sizes. This enables developers to create responsive layouts for different screen sizes.


## Breaking Changes
Starting with version 3.0, we have modified the way the diagonal screen size is calculated to better support native screen resolution. 
If you require the previous behavior, please set the UseNativeScreenResolution property to false, as follows:

```csharp
public App()
{
            OnScreenSizeMarkup.Maui.Manager.Current.UseNativeScreenResolution = false;

            InitializeComponent();
            .....
}
```
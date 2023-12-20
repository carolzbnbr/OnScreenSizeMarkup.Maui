### OnScreenSizeMarkup: A XAML Markup Extension for MAUI

OnScreenSizeMarkup is a XAML markup extension that allows you to control UI elements based on the device's screen size category.

It allows you to easily define different values for different screen sizes, seamlessly adapt designs to fit different mobile devices, and integrate with XAML syntax to enable a smooth and intuitive implementation process.

# Getting Started
### Installation
The OnScreenSizeMarkup.Maui library is available on NuGet. You can install it using the NuGet Package Manager or by running the following command in the Package Manager Console:
```
Install-Package OnScreenSizeMarkup.Maui
```


### **Where can I use it?**

OnScreenSizeMarkup is currently supported for .NET MAUI [![NuGet Stats](https://img.shields.io/nuget/v/OnScreenSizeMarkup.Maui?style=plastic)](https://www.nuget.org/packages/OnScreenSizeMarkup.Maui).

If you are a Xamarin developer you can find an **outdated** version of this library for Xamarin.Forms [here](https://github.com/carolzbnbr/OnScreenSizeMarkup) - sorry folks :(


### Changes to Screen Size Calculations (Breaking Change)
Starting with version 3.0, we have modified the way the diagonal screen size is calculated to better support native screen resolution. If you require the previous behavior, please set the *UseNativeScreenResolution* property to *false*, as follows:

```cs

public App()
{
            OnScreenSizeMarkup.Maui.Manager.Current.UseNativeScreenResolution = false;

            InitializeComponent();

            .....
}
```




### **Supported Platforms**

* `iOS` - iPhones and Tablets
* `Android` - Android Smartphones and Tablets



### **How does it work?**

#### Categorization

Screen are grouped into six categories, allowing for precise UI control. You can set specific values for each category in XAML.

* `ExtraSmall` - Tiny devices as an Apple Watch.
* `Small` - Small devices, such as a Google Pixel 5.
* `Medium` - Medium devices such as IPhone 12.
* `Large` - Large devices such as an IPhone 13 Pro Max.
* `ExtraLarge` - Extra large devices such as tablets.

### Understanding the Properties of Markup

The markup extension has many properties which will be eligible to be used based on the categorized screen size

* `ExtraSmall` - Applied when the device screen size is categorized as ExtraSmall
* `Small` - Applied when the device screen size is categorized as ExtraSmall
* `Medium` - Applied when the device screen size is categorized as ExtraSmall
* `Large` - Applied when the device screen size is categorized as ExtraSmall
* `ExtraLarge` - Applied when the device screen size is categorized as ExtraSmall
* `Default` - Applied when one of the required property above is missing

* `Base` - This is a special property, used in conjunction with the previous ones. 
Use it to set numeric values such as double, float, int, single, etc. 
This property allows the use of Scaled Values, where the base/initial value is defined on this property, and the scale factor should be specified on the previous ones. This allows, for instance, to scale a Grid Row, Grid Column, widthRequest, HeightRequest, FontSizes, etc., based on the size of the screen. See more in the Scaled Values section below.


#### Category Mappings

Below is a table which serves as a way to associate a screen size category with a physical diagonal screen size.
Currently, the library is pre configured to categorize screen sizes based on mobile sizes:

| Diagonal Size | Category   | Size Mode        |
|---------------|------------|------------------|
| 3.9           | ExtraSmall | SmallerOrEqualsTo |
| 4.9           | Small      | SmallerOrEqualsTo |
| 6.2           | Medium     | SmallerOrEqualsTo |
| 7.9           | Large      | SmallerOrEqualsTo |
| 200.0         | ExtraLarge | SmallerOrEqualsTo |

As per the table above, if the device diagonal size is smaller or equals to 3.9 inches, it will be categorized as ExtraSmall.
The same applies to the other categories/diagonal sizes.

#### Can I define my own category mappings?

Sure you can! 
Inside your app.cs file, **before** the initializeComponent, add your own mappings as follows:

```cs
// Add the following Usings.
using OnScreenSizeMarkup.Maui;
using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Mappings;

public App()
{
            Manager.Mappings = new List<SizeMappingInfo>
            {
                new SizeMappingInfo(3.9, ScreenCategories.ExtraSmall, ScreenSizeCompareModes.SmallerOrEqualsTo),
                new SizeMappingInfo(4.9, ScreenCategories.Small, ScreenSizeCompareModes.SmallerOrEqualsTo),
                new SizeMappingInfo(6.2, ScreenCategories.Medium, ScreenSizeCompareModes.SmallerOrEqualsTo),
                new SizeMappingInfo(7.9, ScreenCategories.Large, ScreenSizeCompareModes.SmallerOrEqualsTo),
                new SizeMappingInfo(200.0, ScreenCategories.ExtraLarge, ScreenSizeCompareModes.SmallerOrEqualsTo),
            };

            InitializeComponent();

            .....
}
```


## Non-Scaled Values
Based on a matched screen category, it will return the value defined on a property for that category.

For instance:

In the example below, the row height will be 3* for ExtraSmall devices, 0.8* for Medium devices, and 1* for Large and ExtraLarge devices, and a default value will be assumed for the non specified properties.
```xml
<Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="{markups:OnScreenSize Default='3*', Medium='0.8*', Large='*', ExtraLarge='*'}" />
                    </Grid.RowDefinitions>
    
    ....
</Grid>
```

### Usage
Using the markup is straightforward. 
You can apply it to most UI View elements such as Labels, Grids, Buttons, ImageButtons, etc, as follows:

#### XAML Code Example:
```xml
<ContentPage xmlns:markups="clr-namespace:OnScreenSizeMarkup.Forms;assembly=OnScreenSizeMarkup.Forms">
    <ContentPage.Content>
        <Grid RowDefinitions="{markups:OnScreenSize Large='200, *, 200', ExtraLarge='300, *, 300', DefaultSize='100, *, 100'}">
            <Label Padding="{markups:OnScreenSize Medium='15, 15, 0, 0', Large='20, 20, 0, 0', DefaultSize='10, 10, 0, 0'}" Text="Hello" TextColor="White" />
        </Grid>
    </ContentPage.Content>
</ContentPage>
```

#### Use in Styles:
You can also declare the markup inside resource dictionary, app.xaml.cs, or even style files, as follows:


#### App.xaml.cs Example

```xml
<?xml version = "1.0" encoding = "UTF-8" ?>
<Application xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:markups="clr-namespace:OnScreenSizeMarkup.Maui;assembly=OnScreenSizeMarkup.Maui"
             >
    <Application.Resources>
        <ResourceDictionary>
            ...

            <OnPlatform x:Key="ImageSize" x:TypeArguments="x:Double">
                <OnPlatform.Platforms>
                    <On Platform="Android">
                        <markups:OnScreenSize FallbackType="{x:Type x:Double}"
                                              Default="70"
                                              Medium="130"
                                              Large="170"
                                              ExtraLarge="350" />
                    </On>
                    <On Platform="iOS">
                        <markups:OnScreenSize FallbackType="{x:Type x:Double}"
                                              Default="80"
                                              Medium="150"
                                              Large="200"
                                              ExtraLarge="300"
                        />
                    </On>
                </OnPlatform.Platforms>
            </OnPlatform>

            <OnPlatform x:Key="MarginSize" x:TypeArguments="Thickness">
                <OnPlatform.Platforms>
                    <On Platform="Android">
                        <markups:OnScreenSize FallbackType="{x:Type Thickness}"
                                              Default="0,40,0,40"
                                              ExtraSmall="0,40,0,40"
                                              Small="10,40,10,40"     
                                              Medium="25,40,25,40"
                                              Large="35,40,35,40"
                                              ExtraLarge="70,40,70,40" />
                    </On>
                    <On Platform="iOS">
                        <markups:OnScreenSize FallbackType="{x:Type Thickness}"
                                             Default="0,40,0,40"
                                             ExtraSmall="0,40,0,40"
                                             Small="10,40,10,40"     
                                             Medium="20,40,20,40"
                                             Large="40,40,40,40"
                                             ExtraLarge="90,40,90,40" />
                    </On>
                </OnPlatform.Platforms>
            </OnPlatform>

        </ResourceDictionary>
    </Application.Resources>
</Application>
```

#### Resource Dictionaries Example:

```xml
<ContentPage 
            ...
             xmlns:markups="clr-namespace:OnScreenSizeMarkup.Maui;assembly=OnScreenSizeMarkup.Maui">
<ContentPage.Resources>
    
    <ResourceDictionary>
        
        <Style x:Key="ParagraphLabel" TargetType="Label">
            <Setter Property="FontSize" Value="{markups:OnScreenSize ExtraSmall='12',  Small='14',  Medium='14', Large='14', ExtraLarge='28'}"/>
            <Setter Property="HorizontalOptions" Value="Center"/>
        </Style>
        
        <Style x:Key="TableHeadingLabel" TargetType="Label">
            <Setter Property="FontSize" Value="{markups:OnScreenSize ExtraSmall='12', Small='14',  Medium='14', Large='16', ExtraLarge='32'}"/>
            <Setter Property="FontAttributes" Value="Bold"/>
            <Setter Property="HorizontalOptions" Value="Center"/>
            <Setter Property="HorizontalTextAlignment" Value="Center"/>

        </Style>
        
        <Style x:Key="TableDataLabel" TargetType="Label">
            <Setter Property="FontSize" Value="{markups:OnScreenSize ExtraSmall='11', Small='12',  Medium='12', Large='14', ExtraLarge='28'}"/>
            <Setter Property="HorizontalOptions" Value="Center"/>
            <Setter Property="HorizontalTextAlignment" Value="Center"/>
        </Style>

    </ResourceDictionary>

</ContentPage.Resources>
 
    ...
</ContentPage>
```

#### Code-behind Example

```cs
using OnScreenSizeMarkup.Maui.Helpers;

public MainPage()
{
    Grid grid = new Grid
    {
     // Row definitions based on screen size category
    };
    grid.Children.Add(new Label
    {
        Text = "Hello",
        Padding = OnScreenSizeHelpers.Instance.GetScreenSizeValue(default: new Thickness(10, 10, 0, 0), medium: new Thickness(15, 15, 0, 0), large: new Thickness(20, 20, 0, 0))
    });
    Content = grid;
}
```




## Scaled Values
***This is a new feature***.

Scaled Values are values that are automatically scaled based on the device's screen size category.
It is restricted to primitive numeric values, such as double, int, decimal, etc.

All you have to do is specify a ***Base*** and the scaling factor for each category, as follows:

```xml
    <ResourceDictionary>
            
            <markups:OnScreenSize x:Key="HeadingFontSize" Base="14" ExtraSmall="1" Small="1.2" Medium="1.3" Large="2" ExtraLarge="3"   />
            
    </ResourceDictionary>

<Label
    Text="Hello World!"
    FontSize="{StaticResource HeadingFontSize}">
</Label>

```
In the above example we are defining a base font size of 14, and scaling factor for each category.
So, if the device is categorized as ExtraSmall, the font size will be 14*1 = 14, if it is categorized as Small, the font size will be 14*1.2 = 16.8, and so on.

using OnScreeenSizeMarkup.Sample.ViewModels;

namespace OnScreeenSizeMarkup.Sample;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        try
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }


    protected override void OnAppearing()
    {
        mappings.ItemsSource = OnScreenSizeMarkup.Maui.Manager.Current.Mappings;
        
        base.OnAppearing();
    }

}
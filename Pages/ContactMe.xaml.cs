using CalculatorDemo2.ViewModels;

namespace CalculatorDemo2.Pages;

public partial class ContactMe : ContentPage
{
    // google app password =  osfo ibkt ndee ciup
    public ContactMe()
	{
		InitializeComponent();


        // Disable the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);

        BindingContext = new ContactMeViewModel();


    }

   


    private async void OnCalculatorTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new MyCalculator());
    }

    private async void onAboutAppTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new AboutApp());
    }


    private async void OnEmailTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ContactMe());
    }

   
}
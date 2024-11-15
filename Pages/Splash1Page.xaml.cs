namespace CalculatorDemo2.Pages;

public partial class Splash1Page : ContentPage
{
	public Splash1Page()
	{
		InitializeComponent();

        // Disable the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);
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
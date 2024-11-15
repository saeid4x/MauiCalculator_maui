using CalculatorDemo2.Pages;

namespace CalculatorDemo2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new  MyCalculator() );
        }
    }
}

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab7B
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new Lab7BListPage())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"]
            };

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

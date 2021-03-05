using BroyLiftFront.Pages;
using Microsoft.WindowsAzure.MobileServices;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BroyLiftFront
{
    public partial class App : Application
    {          
        public static string DatabaseLocation = string.Empty;
        public static MobileServiceClient MobileService =
            new MobileServiceClient(
            "https://broylift.azurewebsites.net"
        );
        public App()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Preferences.Get("accesstoken", "")))
            {
                MainPage = new MasterPage();
            }
            else if (string.IsNullOrEmpty(Preferences.Get("useremail", "")) && string.IsNullOrEmpty(Preferences.Get("password", "")))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
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

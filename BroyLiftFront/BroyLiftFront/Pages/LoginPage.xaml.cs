using BroyLiftFront.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BroyLiftFront.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {      
            public LoginPage()
            {
                InitializeComponent();
                NavigationPage.SetHasNavigationBar(this, false);
            }

        private async void BtnLogin_OnClicked(object sender, EventArgs e)
        {
            ApiService apiService = new ApiService();
            var response = await apiService.GetToken(EntEmail.Text, EntPassword.Text);
            if (string.IsNullOrEmpty(response.access_token))
            {
                await DisplayAlert("Error", "Something wrong", "Alright");
            }
            else
            {
                Preferences.Set("useremail", EntEmail.Text);
                Preferences.Set("password", EntPassword.Text);
                Preferences.Set("accesstoken", response.access_token);
                Application.Current.MainPage = new HomePage();
            }
        }

        private void TapRegister_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new ExercisePage()));
        }

        private void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }
    }
    }

using BroyLiftFront.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BroyLiftFront.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public ObservableCollection<Exercise> Exercises;
        private bool First = true;
        public HomePage()
        {
            InitializeComponent();
        }


        private void BtnTraining_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage (new ExercisePage()));
        }

        private void BtnDiary_Clicked(object sender, EventArgs e)
            {
                Navigation.PushAsync(new DiaryPage());
            }
        }
    }

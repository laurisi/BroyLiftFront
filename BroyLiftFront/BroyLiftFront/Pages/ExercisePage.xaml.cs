using BroyLiftFront.Models;
using BroyLiftFront.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BroyLiftFront.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisePage : ContentPage
    {
        public ExercisePage()
        {
            InitializeComponent();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            var exercise = new Exercise()
            {
                NameOfExercise = EntNameOfExercise.Text,
                Number = EntNumber.Text
            };
            ApiService apiService = new ApiService();
            var response = await apiService.StartExercise(exercise);
            if (!response)
            {
                await DisplayAlert("Oops", "Something trong", "Oops");
            }
            else
            {
                await DisplayAlert("Congratulations", "Yeaah", "Aiiight!");
            }
        }
    }
    }

  
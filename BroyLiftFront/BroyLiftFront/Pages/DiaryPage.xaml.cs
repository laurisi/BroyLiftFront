using BroyLiftFront.Models;
using BroyLiftFront.Services;
using BroyLiftFront.ViewModel;
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
    public partial class DiaryPage : ContentPage
    {
        public ObservableCollection<Exercise> Exercises;
        public DiaryPage()
        {
            InitializeComponent();
            Exercises = new ObservableCollection<Exercise>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ApiService apiService = new ApiService();
            var exercises = await apiService.GetDiary();            
         
        }
    }
}




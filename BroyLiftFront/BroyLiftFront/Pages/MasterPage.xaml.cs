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
	public partial class MasterPage : MasterDetailPage
	{
		public MasterPage()
		{
			InitializeComponent();
		}

		private void TapHome_OnTapped(object sender, EventArgs e)
		{
			Detail = new NavigationPage(new LoginPage());
			IsPresented = false;
		}

		private void TapLogout_OnTapped(object sender, EventArgs e)
		{
			Preferences.Set("useremail", string.Empty);
			Preferences.Set("password", string.Empty);
			Preferences.Set("accesstoken", string.Empty);
			Application.Current.MainPage = new NavigationPage(new LoginPage());
		}
	}
}
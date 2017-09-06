using Xamarin.Forms;
using HiddenMessage.pages.UserTabs;
using HiddenMessage.pages;
using HiddenMessage.Service;
using System.Globalization;
using System;

namespace HiddenMessage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            UserSettings settings = new UserSettings();
            if(!settings.IsUserSaved())
            {
                MainPage = new NewUserPage();
            }else{
                MainPage = new NavigationPage(new MainTabbedPages());
            }
        }

        protected override void OnStart()
        {
            System.Diagnostics.Debug.WriteLine("xoxostart");
        }

        protected override void OnSleep()
        {
			System.Diagnostics.Debug.WriteLine("xoxosleep");
		}

        protected override void OnResume()
        {
			System.Diagnostics.Debug.WriteLine("xoxoresume");

		}
    }
}

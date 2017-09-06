using Xamarin.Forms;
using HiddenMessage.pages.UserTabs;
using HiddenMessage.pages;
using HiddenMessage.Service;
using System.Globalization;
using System;
using HiddenMessage.Service.ServerRequests;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HiddenMessage
{
    public partial class App : Application
    {

        private UserSettings settings;

        public App()
        {
            InitializeComponent();

            settings = new UserSettings();
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
            if (settings.IsUserSaved())
            {
                System.Diagnostics.Debug.WriteLine("xoxostart: set online");
				string route = "/users/online_status/" + settings.UserId;

                Dictionary<string, string> onlineStatusHash = new Dictionary<string, string>()
                { {"onlineStatus", "online"} };
                string json = JsonConvert.SerializeObject(onlineStatusHash);

                HttpRequest.MakePutRequest(ServerVariables.URL + route, json, null);
            }
        }

        protected override void OnSleep()
        {
			System.Diagnostics.Debug.WriteLine("xoxosleep"); 
            if (settings.IsUserSaved())
			{
                System.Diagnostics.Debug.WriteLine("xoxosleep: set offline");
				string route = "/users/online_status/" + settings.UserId;

				Dictionary<string, string> onlineStatusHash = new Dictionary<string, string>()
				{ {"onlineStatus", "offline"} };
				string json = JsonConvert.SerializeObject(onlineStatusHash);

				HttpRequest.MakePutRequest(ServerVariables.URL + route, json, null);
			}
		}

        protected override void OnResume()
        {
			System.Diagnostics.Debug.WriteLine("xoxoresume");
			if (settings.IsUserSaved())
			{
                System.Diagnostics.Debug.WriteLine("xoxoresume: set online");
				string route = "/users/online_status/" + settings.UserId;

				Dictionary<string, string> onlineStatusHash = new Dictionary<string, string>()
				{ {"onlineStatus", "online"} };
				string json = JsonConvert.SerializeObject(onlineStatusHash);

				HttpRequest.MakePutRequest(ServerVariables.URL + route, json, null);
			}

		}
    }
}

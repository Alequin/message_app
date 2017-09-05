﻿using Xamarin.Forms;
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
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

using System;
using System.Collections.Generic;
using HiddenMessage.ViewModels;
using Xamarin.Forms;

namespace HiddenMessage.pages.UserTabs
{
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();


            ListView lv = (ListView)list;

            List<UserListViewModel> content = new List<UserListViewModel>();


            lv.HasUnevenRows = true;
            lv.ItemsSource = content;
        }
    }
}

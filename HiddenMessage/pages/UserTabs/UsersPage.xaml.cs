using System;
using System.Collections.Generic;
using HiddenMessage.Models;
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
            content.Add(new UserListViewModel(new User("bob", 0, null, null, "Online", true)));

            lv.HasUnevenRows = true;
            lv.ItemsSource = content;
        }
    }
}

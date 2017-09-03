using System;
using System.Collections.Generic;
using HiddenMessage.Models;
using HiddenMessage.Service;
using HiddenMessage.Service.ServerRequests;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Dynamic;
using System.Collections.ObjectModel;
using HiddenMessage.ViewModels;

namespace HiddenMessage.pages.UserTabs
{
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();


            ListView lv = (ListView)list;
            ObservableCollection<UserListViewModel> users = new ObservableCollection<UserListViewModel>();
            lv.ItemsSource = users;

            //HttpRequest.MakeGetRequest(ServerVariables.URL + "/users", (content) => {
            //    JObject[] usersAsJson = JsonHelper.DeserialiseArray(content);

            //    for (int j = 0; j < usersAsJson.Length; j++)
            //    {
            //        User user = new User(usersAsJson[j]);
            //        users.Add(new UserListViewModel(user));
            //    }
            //    return null;
            //});
        }
    }
}

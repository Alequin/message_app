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

        UserSettings settings = new UserSettings();

        public UsersPage()
        {
            InitializeComponent();

            ListView lv = (ListView)list;
            ObservableCollection<UserListViewModel> users = new ObservableCollection<UserListViewModel>();
            lv.ItemsSource = users;

			lv.ItemTapped += async (sender, e) =>
			{
                UserListViewModel selectedViewModel = (UserListViewModel)e.Group;
                bool answer = await DisplayAlert("", "Start a conversations with " + selectedViewModel.Name, "Yes", "No");
                if(answer){
                    this.StartConversation(selectedViewModel.UserId);
                }
			};

            HttpRequest.MakeGetRequest(ServerVariables.URL + "/users", (content) => {
                JObject[] usersAsJson = JsonHelper.DeserialiseArray(content);

                foreach (JObject jsonUser in usersAsJson)
                {
                    if((int)jsonUser["id"] != settings.UserId)
                    {
						User user = new User(jsonUser);
						users.Add(new UserListViewModel(user)); 
                    }
                }
                return null;
            });
        }

        private void StartConversation(int userToStartWith)
        {
            string route = $"/conversations/user/{settings.UserId}/other_user/{userToStartWith}";
            HttpRequest.MakePostRequest(ServerVariables.URL + route, "", null); 
        }
    }
}

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

        private UserSettings settings = new UserSettings();
        private ListView listView;
        public ListView ListView
        {
            get { return listView; }
        }

        private ObservableCollection<UserListViewModel> users;

        public UsersPage()
        {
            InitializeComponent();

            listView = (ListView)list;
            users = new ObservableCollection<UserListViewModel>();
            listView.ItemsSource = users;
            this.UpdateUserList();
        }

        private void UpdateUserList()
        {
			HttpRequest.MakeGetRequest(ServerVariables.URL + "/users", (content) => {
				JObject[] usersAsJson = JsonHelper.DeserialiseArray(content);
                users.Clear();

				foreach (JObject jsonUser in usersAsJson)
				{
					if ((int)jsonUser["id"] != settings.UserId)
					{
						User user = new User(jsonUser);
						users.Add(new UserListViewModel(user));
					}
				}
				return null;
			});
        }

        public void OnClickUpdate(Object sender, EventArgs e)
        {
            this.UpdateUserList();
        }
    }
}

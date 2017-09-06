using System;
using System.Collections.Generic;
using HiddenMessage.pages.UserTabs;
using HiddenMessage.Service;
using HiddenMessage.Service.ServerRequests;
using HiddenMessage.ViewModels;
using Xamarin.Forms;

namespace HiddenMessage.pages
{
    public partial class MasterMessagePage : MasterDetailPage
    {
        private int conversationId;

        public MasterMessagePage(int conversationId)
        {
            InitializeComponent();
            this.conversationId = conversationId;
            Detail = new MessagePage(conversationId);
        }

        void OnClickToMessagesButton(object sender, System.EventArgs e)
		{
			Detail = new MessagePage(conversationId);
        }

        void OnClickToInviteButton(object sender, System.EventArgs e)
        {
            UsersPage usersPage = new UsersPage();
            Detail = usersPage;

			usersPage.ListView.ItemTapped += async (listView, elements) =>
			{
				UserListViewModel selectedViewModel = (UserListViewModel)elements.Item;
                bool answer = await DisplayAlert("", $"Invite {selectedViewModel.Name} to the conversation?", "Yes", "No");
				if (answer)
				{
                    string route = $"/participants/user/{selectedViewModel.UserId}/conversation/{this.conversationId}";
                    HttpRequest.MakePostRequest(ServerVariables.URL + route, "", null);	
				}
				((ListView)listView).SelectedItem = null;
			};
        }

		void OnClickLeaveButton(object sender, System.EventArgs e)
		{
			this.HandleOnLeaveConversation();
		}

        private async void HandleOnLeaveConversation()
        {
			bool answer = await DisplayAlert("", "Are you sure you wish to leave?", "Yes", "No");
			if (answer)
			{
                UserSettings settings = UserSettings.SettingsInstance;
				string route = $"/participants/user/{settings.UserId}/conversation/{this.conversationId}";
				HttpRequest.MakeDeleteRequest(ServerVariables.URL + route, null);
			}
            Navigation.PushAsync(new NavigationPage(new MainTabbedPages()));
        }
    }
}

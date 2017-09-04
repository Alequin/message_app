using System.Collections.Generic;
using HiddenMessage.Service;
using HiddenMessage.Service.ServerRequests;
using HiddenMessage.ViewModels;
using Xamarin.Forms;

namespace HiddenMessage.pages.UserTabs
{
    public partial class MainTabbedPages : TabbedPage
    {

        private UserSettings settings = new UserSettings();
        private ConversationPage convoPage;

        public MainTabbedPages()
        {
            InitializeComponent();

            UsersPage usersPage = new UsersPage();
            this.Children.Add(usersPage);

			usersPage.ListView.ItemTapped += async (sender, e) =>
			{
                UserListViewModel selectedViewModel = (UserListViewModel)e.Item;
				bool answer = await DisplayAlert("", "Start a conversations with " + selectedViewModel.Name, "Yes", "No");
				if (answer)
				{
					this.StartConversation(selectedViewModel.UserId);

				}
				((ListView)sender).SelectedItem = null;
			};

            convoPage = new ConversationPage();
			this.Children.Add(convoPage);

			this.Children.Add(new SettingsPage());
        }

		private async void StartConversation(int userToStartWith)
		{
            System.Diagnostics.Debug.WriteLine("out 1: " + userToStartWith);
            string route = $"/conversations/user/{settings.UserId}/other_user/{userToStartWith}";
			await HttpRequest.MakePostRequest(ServerVariables.URL + route, "", null);
			convoPage.UpdateConversations();

		}
    }
}

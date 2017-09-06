using System;
using System.Collections.Generic;
using HiddenMessage.pages.UserTabs;
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
				    	
				}
				((ListView)listView).SelectedItem = null;
			};
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HiddenMessage.Service;
using HiddenMessage.Service.ServerRequests;
using HiddenMessage.ViewModels;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace HiddenMessage.pages.UserTabs
{
    public partial class ConversationPage : ContentPage
    {

        private UserSettings settings = new UserSettings();
        private ObservableCollection<ConversationListViewModel> convos;

        public ConversationPage()
        {
            InitializeComponent();

			ListView listView = (ListView)list;
			convos = new ObservableCollection<ConversationListViewModel>();
			listView.ItemsSource = convos;
            listView.ItemTapped += (sender, e) =>
            {
                ConversationListViewModel selected = (ConversationListViewModel)e.Item;
                Navigation.PushAsync(new MessagePage(selected.ConversationId));
                ((ListView)sender).SelectedItem = null;
            };

			this.UpdateConversations();
		}

        public void UpdateConversations()
        {
			String route = "/conversations/participants/user/" + settings.UserId.ToString();
			HttpRequest.MakeGetRequest(ServerVariables.URL + route, (content) => {
				JObject[] convosAsJson = JsonHelper.DeserialiseArray(content);

                convos.Clear();
				foreach (JObject token in convosAsJson)
				{
					convos.Add(new ConversationListViewModel((int)token["conversationId"], "last message", ChangeJTokenArrayToStringArray(token["usersCollection"])));
				}

				return null;
			});
        }

        void OnClickUpdate(object sender, System.EventArgs e)
        {
            this.UpdateConversations();
        }

        private List<String> ChangeJTokenArrayToStringArray(JToken jsonArray)
        {
            List<String> usersList = new List<string>();
            JToken token = jsonArray.First;

            while(token != null){
                usersList.Add(token.ToString());
                token = token.Next;
            }

            return usersList;
        }
    }
}

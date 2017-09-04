using System;
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

        UserSettings settings = new UserSettings();

        public ConversationPage()
        {
            InitializeComponent();

			ListView listView = (ListView)list;
			ObservableCollection<ConversationListViewModel> convos = new ObservableCollection<ConversationListViewModel>();
			listView.ItemsSource = convos;

            //String route = "/conversations/participants/user/" + settings.UserId.ToString();
			//HttpRequest.MakeGetRequest(ServerVariables.URL + route, (content) => {
			//	JObject[] convosAsJson = JsonHelper.DeserialiseArray(content);

			//	return null;
			//});
		}
    }
}

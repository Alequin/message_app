using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HiddenMessage.Service;
using HiddenMessage.Service.ServerRequests;
using HiddenMessage.ViewModels;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace HiddenMessage.pages
{
    public partial class MessagePage : ContentPage
    {

        private int conversationId;

        public MessagePage(int conversationId)
        {
            InitializeComponent();

            this.conversationId = conversationId;

            ObservableCollection<MessageViewModel> messages = new ObservableCollection<MessageViewModel>();

            //string route = "/messages/conversation/" + conversationId;
            string route = "/messages/conversation/5";
			HttpRequest.MakeGetRequest(ServerVariables.URL + route, (result) => {
                JObject[] messagesAsJson = JsonHelper.DeserialiseArray(result);

                System.Diagnostics.Debug.WriteLine(messagesAsJson);

                return null;
            }); 
        }
    }
}

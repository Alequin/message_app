using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HiddenMessage.Models;
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
        private UserSettings settings = new UserSettings();

        public MessagePage(int conversationId)
        {
            InitializeComponent();

            this.conversationId = conversationId;

            ObservableCollection<MessageViewModel> messages = new ObservableCollection<MessageViewModel>();

            string route = "/messages/conversation/" + conversationId;

			HttpRequest.MakeGetRequest(ServerVariables.URL + route, (result) => {
                JObject[] messagesAsJson = JsonHelper.DeserialiseArray(result);

                foreach(JObject jsonMessage in messagesAsJson)
                {
                    System.Diagnostics.Debug.WriteLine("Out:" + jsonMessage);  
                }
                return null;
            }); 
        }

        void OnClickSendButton(object sender, System.EventArgs e)
        {
            string messageBody = ((Entry)sender).Text;
            Message message = new Message(messageBody, settings.UserId, this.conversationId, null);
            message.Save(null);
        }
    }
}

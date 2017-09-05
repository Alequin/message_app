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
            string messageBody = messageEntry.Text;
            string time = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss");
            Message message = new Message(messageBody, settings.UserId, this.conversationId, time);
            message.Save(null);
            messageEntry.Text = "";
        }
    }
}

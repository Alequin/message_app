using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

        private Task updateTask;
        private bool runUpdate;
        private int conversationId;
        private UserSettings settings = new UserSettings();

        ObservableCollection<MessageViewModel> messages;

        public MessagePage(int conversationId)
        {
            InitializeComponent();

            this.conversationId = conversationId;

            messages = new ObservableCollection<MessageViewModel>();
            list.ItemsSource = messages;

			this.UpdateMessages();

            runUpdate = true;
			updateTask = new Task(async () => {
				while (runUpdate)
				{
					this.UpdateMessages();
					await Task.Delay(10000);
				}
			});
            updateTask.Start();
        }

        private void UpdateMessages()
        {
            string route = "/messages/conversation/" + conversationId;
			HttpRequest.MakeGetRequest(ServerVariables.URL + route, (result) => {
				JObject[] messagesAsJson = JsonHelper.DeserialiseArray(result);

                messages.Clear();
				foreach (JObject jsonMessage in messagesAsJson)
				{
					messages.Add(new MessageViewModel(jsonMessage));
				}
				return null;
			});
        }

        void OnClickSendButton(object sender, System.EventArgs e)
        {
            string messageBody = messageEntry.Text;
            Message message = new Message(messageBody, settings.UserId, this.conversationId, "");
            message.Save(null);
            messageEntry.Text = "";
        }

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
            runUpdate = false;
		}
    }
}

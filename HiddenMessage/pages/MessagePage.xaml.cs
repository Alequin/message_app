using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
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
        private CancellationTokenSource taskCanceler;

        private int conversationId;
        private UserSettings settings = UserSettings.SettingsInstance;

        ObservableCollection<MessageViewModel> messages;

        public MessagePage(int conversationId)
        {
            InitializeComponent();

            this.conversationId = conversationId;

            messages = new ObservableCollection<MessageViewModel>();
            list.ItemsSource = messages;

			this.UpdateMessages();

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

        private void StartUpdateMessageLoop()
        {
            taskCanceler = new CancellationTokenSource();
            CancellationToken ct = taskCanceler.Token;
			updateTask = new Task(async () => {
                bool run = true;
				while (run)
				{
					await Task.Delay(10000);
					this.UpdateMessages();
					if (ct.IsCancellationRequested)
					{
                        run = false;
					}
				}
			}, taskCanceler.Token);
            updateTask.Start();
        }

        void OnClickSendButton(object sender, System.EventArgs e)
        {
            string messageBody = messageEntry.Text;
            Message message = new Message(messageBody, settings.UserId, this.conversationId, "");
            messages.Add(new MessageViewModel(message.MessageBody, settings.UserName, "Just now"));
            message.Save(null);
            messageEntry.Text = "";
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
            this.StartUpdateMessageLoop();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
            taskCanceler.Cancel();
            updateTask = null;
			taskCanceler.Dispose();
		}
    }
}

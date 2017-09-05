using System;
using Newtonsoft.Json.Linq;

namespace HiddenMessage.ViewModels
{
    public class MessageViewModel
    {

        private String messageDetails;
        private String message;

        public MessageViewModel(string message, string sendingUser, string timeStamp)
        {
            this.messageDetails += sendingUser + ": " + timeStamp;
            this.message = message;
        }

		public MessageViewModel(JObject message)
            :this (message["messageBody"].ToString(), message["userName"].ToString(), message["sentTimestamp"].ToString()){}

        public String MessageDetails
        {
            get { return messageDetails; }
        }

		public String Message
		{
			get { return message; }
		}
    }
}

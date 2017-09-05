using System;
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

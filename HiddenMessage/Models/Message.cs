using System;
using System.Collections.Generic;
using HiddenMessage.Service;
using HiddenMessage.Service.ServerRequests;
using Newtonsoft.Json;

namespace HiddenMessage.Models
{
    public class Message
    {

        private String messageBody;
        private int userId;
        private int conversationId;
        private String sentTimestamp;

        public Message(string messageBody, int userId, int conversationId, string sentTimestamp)
        {
            this.messageBody = messageBody;
            this.userId = userId;
            this.conversationId = conversationId;
            this.sentTimestamp = sentTimestamp;
        }

        public String MessageBody
        {
            get { return messageBody; }
        }

		public async void Save(Func<String, String> onComplete)
		{
			await HttpRequest.MakePostRequest(ServerVariables.URL + "/messages", this.ToJsonString(), onComplete);
		}

		private String ToJsonString()
		{
            Dictionary<string, Object> jsonHash = new Dictionary<string, Object>
            {
                { "messageBody", this.messageBody },
                { "userId", this.userId },
                { "conversationId", this.conversationId },
                { "sentTimestamp", this.sentTimestamp}
            };
            Dictionary<string, Dictionary<string, object>> jsonContainerHash = new Dictionary<string, Dictionary<string, object>>
            {
                { "message", jsonHash }
            };
            return JsonConvert.SerializeObject(jsonContainerHash);
		}
    }
}

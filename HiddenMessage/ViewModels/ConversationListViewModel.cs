﻿using System;
using System.Collections.Generic;

namespace HiddenMessage.ViewModels
{
    public class ConversationListViewModel
    {

        private int conversationId;
        private List<String> usersCollection;
        private String usersText;
        private String lastMessage;

        public ConversationListViewModel(int conversationId, String lastMessage, List<String> usersCollection)
        {
            this.conversationId = conversationId;
            this.lastMessage = lastMessage;
            this.usersCollection = usersCollection;
            this.usersText = BuildUsersText();
        }

		public int ConversationId
		{
			get { return conversationId; }
		}

        public String UsersText
        {
            get { return "Users: " + usersText; }
        }

		public String LastMessage
		{
			get { return lastMessage; }
		}

        public void AddUser(String userName)
        {
            usersCollection.Add(userName);
            this.usersText = BuildUsersText();
        }

        private String BuildUsersText(){

            string text = "";
            int length = usersCollection.Count;
            for (int j = 0; j < length; j++)
            {
                String user = usersCollection[j];
                text += user;
                if (j < length - 1) text += ", ";   
            }

            return text;
        }
    }
}

using System;
using System.Collections.Generic;

namespace HiddenMessage.ViewModels
{
    public class ConversationListViewModel
    {

        private List<String> usersCollection;
        private String usersText;
        private String lastMessage;

        public ConversationListViewModel(String lastMessage, List<String> usersCollection)
        {
            this.lastMessage = lastMessage;
            this.usersCollection = usersCollection;
            this.usersText = BuildUsersText();
        }

        public String UsersText
        {
            get { return "Users: " + usersText; }
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

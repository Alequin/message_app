using System;
namespace HiddenMessage.ViewModels
{
    public class ConversationListViewModel
    {

        private String[] usersCollection;
        private String usersText;
        private String lastMessage;

        public ConversationListViewModel(String lastMessage, String[] usersCollection)
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
            int length = usersCollection.Length;
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

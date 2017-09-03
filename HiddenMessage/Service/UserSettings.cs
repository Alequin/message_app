using System;
using HiddenMessage.Models;
using Xamarin.Forms;

namespace HiddenMessage.Service
{
    public class UserSettings
    {

        private int userId;
        private readonly string ID_KEY = "key";

        private String userName;
        private readonly string NAME_KEY = "user_name";

        public UserSettings()
        {
            this.Load();
        }

        public int UserId
        {
            get { return userId; }
        }

        private int LoadUserId(){
            return (int)Application.Current.Properties[ID_KEY];
        }

		public String UserName
		{
            get { return userName; }
            set { userName = value; }
		}

        private String LoadUserName(){
            return (String)Application.Current.Properties[NAME_KEY];
        }

        public void Load()
        {
            this.userId = this.LoadUserId();
            this.userName = this.LoadUserName();
        }

        public void SaveNewUser(User newUser)
        {
            this.userId = newUser.Id;
            this.userName = newUser.Name;

			Application.Current.Properties[ID_KEY] = this.userId;
			Application.Current.Properties[NAME_KEY] = this.userId;
        } 
    }
}

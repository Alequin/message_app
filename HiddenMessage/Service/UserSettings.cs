using System;
using HiddenMessage.Models;
using Xamarin.Forms;

namespace HiddenMessage.Service
{
    public class UserSettings
    {

        private static UserSettings settingsInstance = new UserSettings();
        public static UserSettings SettingsInstance
        {
            get { return settingsInstance; }
        }

        private int userId;
        private readonly string ID_KEY = "key";

        private String userName;
        private readonly string NAME_KEY = "user_name";

        private UserSettings()
        {
            this.Load();
        }

        public int UserId
        {
            get { return userId; }
        }


		public String UserName
		{
            get { return userName; }
            set { userName = value; }
		}

        public void Load()
        {
            this.userId = this.LoadUserId();
            this.userName = this.LoadUserName();
        }

        public bool IsUserSaved()
        {
            return (this.IsUserIdSaved() && this.IsUserNameSaved());
        }

        public void SaveNewUser(User newUser)
        {
            this.userId = newUser.Id;
            this.userName = newUser.Name;

			Application.Current.Properties[ID_KEY] = this.userId;
			Application.Current.Properties[NAME_KEY] = this.userName;
        }

		private int LoadUserId()
		{
            
            if(IsUserIdSaved()) return (int)Application.Current.Properties[ID_KEY];
            return -1;
		}

		private bool IsUserIdSaved()
		{
			return Application.Current.Properties.ContainsKey(ID_KEY);
		}

		private String LoadUserName()
		{
            if(IsUserNameSaved()) return (String)Application.Current.Properties[NAME_KEY];
            return "";
		}

		private bool IsUserNameSaved()
		{
			return Application.Current.Properties.ContainsKey(NAME_KEY);
		}
    }
}

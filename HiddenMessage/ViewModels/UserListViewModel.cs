using System;
using HiddenMessage.Models;
using Xamarin.Forms;

namespace HiddenMessage.ViewModels
{
    public class UserListViewModel
    {

        private string avatarUrl;
        public string AvatarUrl
        { 
            get { return avatarUrl; } 
            set { avatarUrl = value; }
        }

		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string onlineStatus;
		public string OnlineStatus
		{
			get { return onlineStatus; }
			set 
            { 
                onlineStatus = value;
				switch (onlineStatus)
				{
					case "Offline":
                        onlineStatusColour = (Color)Application.Current.Resources["offlineColour"];
						break;
					default:
						onlineStatusColour = Color.Black;
						break;
				}
            }
		}

        private Color onlineStatusColour;
        public Color OnlineStatusColour
        {
            get { return onlineStatusColour; }  
        }

        public UserListViewModel(User user)
        {
            this.AvatarUrl = "general_user.png";
            this.Name = user.Name;
            this.OnlineStatus = user.OnlineStatus;
        }
    }
}


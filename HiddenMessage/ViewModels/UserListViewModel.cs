using System;
using HiddenMessage.Models;

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
			set { onlineStatus = value; }
		}

        public UserListViewModel(User user)
        {
            this.avatarUrl = "general_user.png";
            this.name = user.Name;
            this.onlineStatus = user.OnlineStatus;
        }
    }
}

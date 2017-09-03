using System;
namespace HiddenMessage.ViewModels
{
    public class UserListViewModel
    {

		private string avatar;
		private string Avatar{ get; set; }

		private string name;
		private string Name{ get; set; }

		private string onlineStatus;
		private string OnlineStatus{ get; set; }

        public UserListViewModel(string avatar, string name, string onlineStatus)
        {
            this.avatar = avatar;
            this.name = name;
            this.onlineStatus = onlineStatus;
        }
    }
}

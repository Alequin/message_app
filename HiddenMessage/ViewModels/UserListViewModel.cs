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

        public UserListViewModel(UserListViewModel user)
        {
            this.avatar = user.Avatar;
            this.name = user.Name;
            this.onlineStatus = user.OnlineStatus;
        }
    }
}

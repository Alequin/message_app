using System;
namespace HiddenMessage.Models
{
    public class User
    {

        private String name;
        private int avatar;
        private String deviceSystem;
        private String deviceToken;
        private String onlineStatus;
        private bool isVisible;

        public User(String name, int avatar, String deviceSystem, String deviceToken, String onlineStatus, bool isVisible)
        {
            this.name = name;
            this.avatar = avatar;
            this.deviceSystem = deviceSystem;
            this.deviceToken = deviceToken;
            this.onlineStatus = onlineStatus;
            this.isVisible = isVisible;
        }

		public User(String name, int avatar, String onlineStatus, bool isVisible)
		: this(name, avatar, null, null, onlineStatus, isVisible){}
    }
}



//function User(name, avatar, deviceSystem, deviceToken, onlineStatus, isVisible)
//{
//	this.id = -1;
//	this.name = name;
//	this.avatar = avatar;
//	this.deviceSystem = deviceSystem
//  this.deviceToken = deviceToken
//  this.onlineStatus = onlineStatus
//  this.isVisible = isVisible
//}


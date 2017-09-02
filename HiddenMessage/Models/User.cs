using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using HiddenMessage.Service.ServerRequests;

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
        
        public String Name { get { return name; } }
		public int Avatar { get { return avatar; } }
        public String DeviceSystem { get  {return deviceSystem; } }
		public String DeviceToken { get { return deviceToken; } }
        public String OnlineStatus { get { return onlineStatus; } }
		public bool IsVisible { get { return isVisible; } }

        public async void Save(){
            this.Save(null);
        }

        public async void Save(Func<String, String> onComplete)
        {
			await HttpRequest.MakePostRequest(ServerVariables.SERVER_URL + "/users", this.GetJson(), onComplete);
		}

        private String GetJson()
        {
            Dictionary<string, Object> jsonHash = new Dictionary<string, Object>();
			jsonHash.Add("name", this.Name);
			jsonHash.Add("avatar", this.Avatar);
			jsonHash.Add("deviceSystem", this.DeviceSystem);
			jsonHash.Add("deviceToken", this.DeviceToken);
			jsonHash.Add("onlineStatus", this.OnlineStatus);
			jsonHash.Add("isVisible", this.IsVisible);

            Dictionary<string, Dictionary<string, object>> jsonContainerHash = new Dictionary<string, Dictionary<string, object>>();
            jsonContainerHash.Add("user", jsonHash);

            return JsonConvert.SerializeObject(jsonContainerHash);
        }
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


using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using HiddenMessage.Service.ServerRequests;
using System.Collections.Generic;

using System.Linq;
using System.Reflection;

namespace HiddenMessage.Models
{
    public class User
    {

        public String name;
        public int avatar;
        public String deviceSystem;
        public String deviceToken;
        public String onlineStatus;
        public bool isVisible;

        public User(string name, int avatar, string deviceSystem, string deviceToken, string onlineStatus, bool isVisible)
        {
            System.Diagnostics.Debug.WriteLine("out: " + name + "--------------------------------------------------");
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

        public String getJson()
        {
            Dictionary<string, Object> jsonHash = new Dictionary<string, Object>();
			jsonHash.Add("name", this.Name);
			jsonHash.Add("avatar", this.Avatar);
			jsonHash.Add("deviceSystem", this.DeviceSystem);
			jsonHash.Add("deviceToken", this.DeviceToken);
			jsonHash.Add("onlineStatus", this.OnlineStatus);
			jsonHash.Add("isVisible", this.IsVisible);

            Dictionary<string, Dictionary<string, object>> jsonContainerHash = new Dictionary<string, Dictionary<string, object>>();
            jsonContainerHash.Add("User", jsonHash);

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


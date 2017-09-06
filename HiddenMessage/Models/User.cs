using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using HiddenMessage.Service.ServerRequests;
using Newtonsoft.Json.Linq;

namespace HiddenMessage.Models
{
    public class User
    {

        private int id;
        private String name;
        private int avatar;
        private String deviceSystem;
        private String deviceToken;
        private String onlineStatus;
        private bool isVisible;

        private User(int id, String name, int avatar, String deviceSystem, String deviceToken, String onlineStatus, bool isVisible)
        {
            this.id = id;
            this.name = name;
            this.avatar = avatar;
            this.deviceSystem = deviceSystem;
            this.deviceToken = deviceToken;
            this.onlineStatus = onlineStatus;
            this.isVisible = isVisible;
        }

		public User(String name, int avatar, String deviceSystem, String deviceToken, String onlineStatus, bool isVisible)
		    : this(-1, name, avatar, deviceSystem, deviceToken, onlineStatus, isVisible) { }

		public User(String name, int avatar, String onlineStatus, bool isVisible)
		    : this(-1, name, avatar, null, null, onlineStatus, isVisible){}

		public User(JObject user)
            : this((int)user["id"], user["name"].ToString(), (int)user["avatar"], 
                   user["deviceSystem"].ToString(), user["deviceToken"].ToString(), 
                   user["onlineStatus"].ToString(), (bool)user["isVisible"]){}

		public int Id { get { return id; } }
        public String Name 
        { 
            get { return name; } 
            set { name = value; } 
        }
		public int Avatar {
			get { return avatar; }
			set { avatar = value; }
		}
        public String DeviceSystem {
			get { return deviceSystem; }
			set { deviceSystem = value; }
		}
		public String DeviceToken {
			get { return deviceToken; }
			set { deviceToken = value; }
		}
        public String OnlineStatus {
			get { return onlineStatus; }
			set { onlineStatus = value; }
		}
		public bool IsVisible {
			get { return isVisible; }
			set { isVisible = value; }
		}

        public async void Save(){
            this.Save(null);
        }

        public async void Save(Func<String, String> onComplete)
        {
			await HttpRequest.MakePostRequest(ServerVariables.URL + "/users", this.ToJsonString(), onComplete);
		}

        private String ToJsonString()
        {
            Dictionary<string, Object> jsonHash = new Dictionary<string, Object>
            {
                { "name", this.Name },
                { "avatar", this.Avatar },
                { "deviceSystem", this.DeviceSystem },
                { "deviceToken", this.DeviceToken },
                { "onlineStatus", this.OnlineStatus },
                { "isVisible", this.IsVisible }
            };
            Dictionary<string, Dictionary<string, object>> jsonContainerHash = new Dictionary<string, Dictionary<string, object>>();
            jsonContainerHash.Add("user", jsonHash);

			return JsonConvert.SerializeObject(jsonContainerHash);
        }
    }
}



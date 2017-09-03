using System;
using System.Collections.Generic;
using HiddenMessage.Models;
using HiddenMessage.Service.ServerRequests;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Dynamic;

namespace HiddenMessage.pages.UserTabs
{
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();


            ListView lv = (ListView)list;

            //HttpRequest.MakeGetRequest(ServerVariables.URL + "/users", (content) => {
                
            //});
        }
    }
}

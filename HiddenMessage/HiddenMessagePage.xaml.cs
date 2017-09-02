using System;
using System.Collections.Generic;
using HiddenMessage.Models;
using HiddenMessage.Service.ServerRequests;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace HiddenMessage
{
    public partial class HiddenMessagePage : ContentPage
    {
        public HiddenMessagePage()
        {
            InitializeComponent();

            User a = new User("bob", 1, null, null, "online", true);
            String userJson = a.getJson();

            System.Diagnostics.Debug.WriteLine(userJson);

            HttpRequest.MakePostRequest(ServerVariables.SERVER_URL + "/users", userJson, (content) => {
                Label b = (Label)Test;
                b.Text = content;
                return null;
            });
        }
    }
}

using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HiddenMessage.pages.UserTabs
{
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();


            ListView lv = (ListView)list;

            List<String> content = new List<string>();
            content.Add("one");
            content.Add("two");
            content.Add("three");

            lv.HasUnevenRows = true;
            lv.ItemsSource = content;
        }
    }
}

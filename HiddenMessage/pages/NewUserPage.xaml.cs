using System;
using System.Collections.Generic;
using HiddenMessage.Models;
using HiddenMessage.Notifications;
using HiddenMessage.Service;
using HiddenMessage.Service.ServerRequests;
using HiddenMessage.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace HiddenMessage.pages
{
    public partial class NewUserPage : ContentPage
    {
        
        private NewUserViewModel newUserViewModel;

        private Entry userNameEntry;

        public NewUserPage()
        {
            InitializeComponent();

            userNameEntry = (Entry) userEntry;

			newUserViewModel = new NewUserViewModel();
			BindingContext = newUserViewModel;
        }

        void OnClickGoButton(object sender, System.EventArgs e)
        {
            String enteredText = userNameEntry.Text;

            if(enteredText == null || enteredText.Length <= 0)
            {
                newUserViewModel.ShowEmptyInputMessage();
                return;
            }

            IToken token = DependencyService.Get<IToken>();
            User newUser = new User(enteredText, 1, Device.RuntimePlatform, token.GetToken(), "Online", true);

            newUser.Save((result) => {
                JObject userJObject = JsonHelper.DeserialiseObject(result);
                User resultantUser = new User(userJObject);

                if(resultantUser.Id > 0){
                    new NavigationPage(new UserTabs.MainTabbedPages());    
                }else{
                    newUserViewModel.ShowNameTakenMessage();
                }

                return null;
            });
        }
    }
}

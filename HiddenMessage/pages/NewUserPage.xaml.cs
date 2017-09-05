using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiddenMessage.Models;
using HiddenMessage.Notifications;
using HiddenMessage.pages.UserTabs;
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
            newUserViewModel.ShowPleaseWaitMessage();
            userNameEntry.IsEnabled = false;
            this.HandleOnClickGoButton();
        }

        private void HandleOnClickGoButton(){

			String enteredText = userNameEntry.Text;

			if (enteredText == null || enteredText.Length <= 0)
			{
				newUserViewModel.ShowEmptyInputMessage();
                userNameEntry.IsEnabled = true;
				return;
			}

			IToken token = DependencyService.Get<IToken>();
			User newUser = new User(enteredText, 1, Device.RuntimePlatform, token.GetToken(), "Online", true);

			newUser.Save((result) => {

				JObject userJObject = JsonHelper.DeserialiseObject(result);
				User resultantUser = new User(userJObject);

				if (resultantUser.Id > 0)
				{
                    new UserSettings().SaveNewUser(resultantUser);
                    Navigation.PushModalAsync(new NavigationPage(new MainTabbedPages()));
				}
				else
				{
					newUserViewModel.ShowNameTakenMessage();
                    userNameEntry.IsEnabled = true;
				}

				return null;
			});
        }
    }
}

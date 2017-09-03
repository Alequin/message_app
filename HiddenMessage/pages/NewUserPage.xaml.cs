using System;
using System.Collections.Generic;
using HiddenMessage.Notifications;
using HiddenMessage.ViewModels;
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
        }
    }
}

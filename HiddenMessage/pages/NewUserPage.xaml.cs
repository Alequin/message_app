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

        public NewUserPage()
        {
            InitializeComponent();

			newUserViewModel = new NewUserViewModel();
			BindingContext = newUserViewModel;
        }

        void OnClickGoButton(object sender, System.EventArgs e)
        {
            newUserViewModel.setInstructionTextToWarningMessage();
            IToken a = DependencyService.Get<IToken>();
            System.Diagnostics.Debug.WriteLine(a.GetToken());
        }
    }
}

using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyCity
{
	public partial class SignInPage : ContentPage
	{
		protected SettingViewModel ViewModel => BindingContext as SettingViewModel;
		public SignInPage()
		{
			InitializeComponent();
			signinButton.Clicked += (sender, e) => {
				if (!checkValue()) {
					return;
				}
				var result = ViewModel.SignIn(emailEntry.Text,passwordEntry.Text);
				if (result == true)
					Navigation.PopAsync();
				else
					DisplayAlert("Warning","Doesn't recognize that email.","OK");
			};
		}

		private bool checkValue() {
			if (emailEntry.Text == null || emailEntry.Text == "") {
				DisplayAlert("Warning","Please input email address.","OK");
				return false;
			}
			if (passwordEntry.Text == null || passwordEntry.Text == "")
			{
				DisplayAlert("Warning", "Please input password.", "OK");
				return false;
			}
			return true;
		}
	}
}

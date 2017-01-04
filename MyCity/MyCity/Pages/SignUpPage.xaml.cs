using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyCity
{
	public partial class SignUpPage : ContentPage
	{
		protected SettingViewModel ViewModel => BindingContext as SettingViewModel;
		public SignUpPage()
		{
			InitializeComponent();
			signupButton.Clicked += (sender, e) => {
				if (!checkValue()) return;
				UserRegistration user = new UserRegistration
				{
					PhoneNumber = phoneEntry.Text,
					EmailId = emailEntry.Text,
					Password = passwordEntry.Text
				};
				var result = ViewModel.SignUp(user);
				if (result == true)
					Navigation.PopAsync();
			};
		}

		private bool checkValue() {
			if (phoneEntry.Text == null || phoneEntry.Text == "") {
				DisplayAlert("Warning","Please input phone number.","OK");
				return false;
			}
			if (emailEntry.Text == null || emailEntry.Text == "")
			{
				DisplayAlert("Warning", "Please input email address.", "OK");
				return false;
			}
			if (passwordEntry.Text == null || passwordEntry.Text == "")
			{
				DisplayAlert("Warning", "Please input password.", "OK");
				return false;
			}
			if (passwordEntry.Text != repasswordEntry.Text)
			{
				DisplayAlert("Warning", "Don't match password", "OK");
				return false;
			}
			return true;
		}
	}
}

using System;
using System.Diagnostics;
using MvvmHelpers;
using Xamarin.Forms;

namespace MyCity
{
    public partial class SettingsPage : ContentPage
    {

		ObservableRangeCollection<Value> _Settins;

        public SettingsPage()
        {
            InitializeComponent();
			_Settins = new ObservableRangeCollection<Value>();
			var value1 = new Value
			{
				Id = 1,
				Text = "Sign In"
			};
			var value2 = new Value
			{
				Id = 2,
				Text = "Sign Up"
			};
			var value3 = new Value
			{
				Id = 3,
				Text = "Contact Us"
			};
			_Settins.Add(value1);
			_Settins.Add(value2);
			_Settins.Add(value3);

			lstView.ItemsSource = _Settins;
        }

		void ItemTapped(object sender, ItemTappedEventArgs e)
		{
			switch (((Value)e.Item).Id) {

				case 1:
					Navigation.PushAsync(new SignInPage() { 
						BindingContext = new SettingViewModel()
					});
					break;
				case 2:
					Navigation.PushAsync(new SignUpPage() { 
						BindingContext = new SettingViewModel()
					});

					break;
				case 3:
					Navigation.PushAsync(new ContactUsPage() { 
						BindingContext = new SettingViewModel()
					});
					break;
				default:
					break;
			}
		}
    }
}

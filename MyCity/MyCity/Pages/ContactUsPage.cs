using System;

using Xamarin.Forms;

namespace MyCity
{
	public class ContactUsPage : ContentPage
	{
		public ContactUsPage()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


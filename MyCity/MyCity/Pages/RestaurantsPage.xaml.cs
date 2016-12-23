using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace MyCity
{
	public partial class RestaurantsPage : ContentPage
	{
		public RestaurantsPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, true);
		}

		void ItemTapped(object sender, EventArgs e) {
			Debug.WriteLine(e);
		}
	}
}

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace MyCity
{
	public partial class RestaurantsPage : ContentPage
	{
		protected RetaurantListViewModel ViewModel => BindingContext as RetaurantListViewModel;
		public RestaurantsPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, true);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			ViewModel.ExecuteLoadAcquaintancesCommand();
		}

		void ItemTapped(object sender, EventArgs e) {
			Debug.WriteLine(e);
		}
	}
}

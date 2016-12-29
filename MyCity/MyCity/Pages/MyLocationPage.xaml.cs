using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XLabs.Forms.Controls;
using Rg.Plugins.Popup.Extensions;

namespace MyCity
{
	public partial class MyLocationPage : ContentPage
	{
		protected MyLocationViewModel ViewModel => BindingContext as MyLocationViewModel;

		public MyLocationPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, true);
			pinButton.Clicked += (sender, e) => {
				
				Navigation.PushPopupAsync(new EnojiView());
			};
		}

		protected override async void OnAppearing() {
			await SetupMap();
		}

		async Task SetupMap()
		{
			if (ViewModel == null) return;
			Xamarin.Forms.Maps.Position position;
			try
			{
				position = await ViewModel.GetPosition();
				this.Title = ""+ await ViewModel.GetCityName(position.Latitude, position.Longitude);
			}
			catch (Exception ex)
			{	
				ViewModel.DisplayGeocodingError();
				Debug.WriteLine(ex.Message);
				return;
			}

			if (position.Latitude.Equals(0.0) && position.Longitude.Equals(0.0))
			{
				ViewModel.DisplayGeocodingError();

				return;
			}

			if (Device.OS != TargetPlatform.WinPhone && Device.OS != TargetPlatform.Windows)
			{
				var pin = new Pin()
				{
					Type = PinType.Place,
					Position = position,
					Label = "Label",
					Address = "Address"
				};
				_map.Pins.Clear();

				_map.Pins.Add(pin);
			}
			_map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(10)));
		}
	}
}

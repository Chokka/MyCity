using System;
using System.Diagnostics;
using System.Collections.Generic;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

namespace MyCity
{
	public partial class EnojiView : PopupPage
	{
		protected MyLocationViewModel ViewModel => BindingContext as MyLocationViewModel;
		public EnojiView()
		{
			InitializeComponent();
			closeButton.Clicked += (sender, e) => {
				PopupNavigation.PopAsync();
			};
			nerd_emojiButton.Clicked += OnEmojiClicked;
			angry_emojiButton.Clicked += OnEmojiClicked;
			love_emojiButton.Clicked += OnEmojiClicked;
			omg_emojiButton.Clicked += OnEmojiClicked;
			crying_emojiButton.Clicked += OnEmojiClicked;
			cold_emojiButton.Clicked += OnEmojiClicked;
		}

		private async void OnEmojiClicked(object sender, EventArgs e)
		{
			Debug.WriteLine(((Button)sender).ClassId);

			DependencyService.Get<MapService>().ChangePin(((Button)sender).ClassId);

			DateTime currentTime = DateTime.Now;
			double minuts = 30;
			currentTime = currentTime.AddMinutes(minuts);
			Xamarin.Forms.Maps.Position position;
			try
			{
				position = await ViewModel.GetPosition();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return;
			}
			int userID = 0;
			if (Singleton.shareInstance().user != null) {
				userID = Singleton.shareInstance().user.Id;
			}
			int attempts = 0;
			var lastSavedLocation = DBManager.sharedInstance().GetLastLocation();
			var pin = DBManager.sharedInstance().GetPinByName(((Button)sender).ClassId);
			if (lastSavedLocation.Latitude.Equals(position.Latitude) && lastSavedLocation.Longitude.Equals(position.Longitude))
			{
				if (lastSavedLocation.PinId == pin.Id)
					attempts = lastSavedLocation.PinningAttempts + 1;
			}

			var markLocation = new MarkMyLocation
			{
				UserId = userID,
				Latitude = position.Latitude,
				Longitude = position.Longitude,
				PinId = pin.Id,
				PinActivatedTime = DateTime.Now.ToLocalTime().ToString(),
				PinningAttempts = attempts,
				IsPinActive = 1,
				IsValidUser = 1,
				Weather = null,
				PinExpiredTime = currentTime.ToString()
			};

			DBManager.sharedInstance().AddLocation(markLocation);

			await PopupNavigation.PopAsync();
		}
	}
}

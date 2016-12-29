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

		private void OnEmojiClicked(object sender, EventArgs e)
		{
			Debug.WriteLine(((Button)sender).ClassId);
			if (Singleton.shareInstance().user == null) {
				DisplayAlert("Warning","You Must login.","OK");
				return;
			}
			DependencyService.Get<MapService>().ChangePin(((Button)sender).ClassId);
			var pin = new CustomPin
			{
				Id = Singleton.shareInstance().user.Id,
				PinName = ((Button)sender).ClassId,
				CreatedDate = DateTime.Now.ToLocalTime().ToString(),
				ModifiedDate = DateTime.Now.ToLocalTime().ToString()
			};

			DBManager.sharedInstance().AddPin(pin);
			PopupNavigation.PopAsync();
		}
	}
}

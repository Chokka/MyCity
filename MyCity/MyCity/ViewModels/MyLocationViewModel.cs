using System;
using System.Linq;
using System.Net.Http;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Newtonsoft.Json;
using Plugin.ExternalMaps;
using Plugin.ExternalMaps.Abstractions;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace MyCity
{
	public class MyLocationViewModel : BaseNavigationViewModel
    {
		IGeolocator locator = null;
		public MyLocationViewModel()
		{
			locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;
		}
    
        public async Task<Xamarin.Forms.Maps.Position> GetPosition()
        {
            IsBusy = true;
			Xamarin.Forms.Maps.Position p;
			try
			{
				if (!locator.IsGeolocationAvailable)
				{
					p = new Xamarin.Forms.Maps.Position();
				}
				if (!locator.IsGeolocationEnabled)
				{
					p = new Xamarin.Forms.Maps.Position();
				}
				var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
				p = new Xamarin.Forms.Maps.Position(position.Latitude,position.Longitude);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				p = new Xamarin.Forms.Maps.Position();
			}
            IsBusy = false;

            return p;
        }

		public async Task<object> GetCityName(double latitude, double longitude) { 
			HttpClient client;
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
			try
			{
				var response = await client.GetAsync("https://maps.googleapis.com/maps/api/geocode/json?latlng=" + latitude + "," + longitude);
				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();
					var json = Newtonsoft.Json.Linq.JObject.Parse(result);
					var reValue = "" + json["results"][0]["formatted_address"];

					var strArr = reValue.Split(',');
					if (strArr.Length > 2)
						return strArr[strArr.Length - 2] + ", " +strArr[strArr.Length - 1];
					else
						return "";
				}
				else {
					Debug.WriteLine(@"Failed.");
					return "Failed";
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"ERROR {0}", ex.Message);
				return ex.Message;
			}
		}

		public void IconChangeCommand(string imgName) { 
			
		}

		public void DisplayGeocodingError()
		{
			IsBusy = false;
		}
    }
}


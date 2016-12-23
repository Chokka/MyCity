using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
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

		public void DisplayGeocodingError()
		{
			IsBusy = false;
		}
    }
}


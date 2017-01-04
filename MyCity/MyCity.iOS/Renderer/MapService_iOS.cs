using System;
using MyCity;
using MyCity.iOS;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(MapService_iOS))]
namespace MyCity.iOS
{
	public class MapService_iOS : MapService
	{
		public void ChangePin(string imgName)
		{
			
		}
	}
}

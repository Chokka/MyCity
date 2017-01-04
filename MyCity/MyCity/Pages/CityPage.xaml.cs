using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyCity
{
    public partial class CityPage : ContentPage
    {
        public CityPage()
        {
            InitializeComponent();

			var imageTapGesture1 = new TapGestureRecognizer();
			imageTapGesture1.Tapped += (sender, e) => {
				Navigation.PushAsync(new RestaurantsPage() { BindingContext = new RetaurantListViewModel()});
			};
			image1.GestureRecognizers.Add(imageTapGesture1);

			var imageTapGesture2 = new TapGestureRecognizer();
			imageTapGesture2.Tapped += (sender, e) =>
			{
				
			};
			image2.GestureRecognizers.Add(imageTapGesture2);

			var imageTapGesture3 = new TapGestureRecognizer();
			imageTapGesture3.Tapped += (sender, e) =>
			{
				
			};
			image3.GestureRecognizers.Add(imageTapGesture3);

			var imageTapGesture4 = new TapGestureRecognizer();
			imageTapGesture4.Tapped += (sender, e) =>
			{
				Navigation.PushAsync(new MyLocationPage() { BindingContext = new MyLocationViewModel()});
			};
			image4.GestureRecognizers.Add(imageTapGesture4);

			var imageTapGesture5 = new TapGestureRecognizer();
			imageTapGesture5.Tapped += (sender, e) =>
			{
				
			};
			image5.GestureRecognizers.Add(imageTapGesture5);

			var imageTapGesture6 = new TapGestureRecognizer();
			imageTapGesture6.Tapped += (sender, e) =>
			{
				
			};
			image6.GestureRecognizers.Add(imageTapGesture6);
        }
    }
}

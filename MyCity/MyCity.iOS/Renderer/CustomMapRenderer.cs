using MyCity;
using MyCity.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.iOS;
using MapKit;
using UIKit;
using System.Diagnostics;
using Foundation;
using CoreGraphics;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace MyCity.iOS
{
	public class CustomMapRenderer : MapRenderer
	{
		string imageName = "angry_emoji.png";
		protected override void OnElementChanged(ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement != null)
			{
				var nativeMap = Control as MKMapView;
				nativeMap.GetViewForAnnotation = null;
				nativeMap.CalloutAccessoryControlTapped -= OnCalloutAccessoryControlTapped;
				nativeMap.DidSelectAnnotationView -= OnDidSelectAnnotationView;
				nativeMap.DidDeselectAnnotationView -= OnDidDeselectAnnotationView;
			}

			if (e.NewElement != null)
			{
				var nativeMap = Control as MKMapView;
				nativeMap.GetViewForAnnotation = GetViewForAnnotation;
				nativeMap.CalloutAccessoryControlTapped += OnCalloutAccessoryControlTapped;
				nativeMap.DidSelectAnnotationView += OnDidSelectAnnotationView;
				nativeMap.DidDeselectAnnotationView += OnDidDeselectAnnotationView;
			}
		}

		MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
		{
			MKAnnotationView annotationView = null;

			if (annotation is MKUserLocation)
				return null;
			
			annotationView = mapView.DequeueReusableAnnotation("mylocation");
			if (annotationView == null)
			{
				annotationView = new MKAnnotationView();
				annotationView.Image = UIImage.FromFile(imageName);
				annotationView.Frame = new CGRect(0, 0, 45, 45);
			}
			annotationView.CanShowCallout = true;

			return annotationView;
		}

		void OnCalloutAccessoryControlTapped(object sender, MKMapViewAccessoryTappedEventArgs e)
		{
			var customView = e.View as MKAnnotationView;

		}

		void OnDidSelectAnnotationView(object sender, MKAnnotationViewEventArgs e)
		{

		}

		CustomPin findCustomPin(string id)
		{
			return null;
		}

		void OnDidDeselectAnnotationView(object sender, MKAnnotationViewEventArgs e)
		{
			if (!e.View.Selected)
			{

			}
		}
	}
}

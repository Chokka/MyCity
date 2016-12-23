using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyCity
{
    public class CityPageCS : ContentPage
    {
        public CityPageCS()
        {

            Icon = "city.png";
            Title = "City";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "City go here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };

        }

    }
}

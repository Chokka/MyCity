using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyCity
{
    public class SocialPageCS : ContentPage
    {
        public SocialPageCS()
        {
            Icon = "today.png";
            Title = "Today";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Social Tab",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }

    }
}

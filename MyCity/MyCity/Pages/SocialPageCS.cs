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
            Icon = "social.png";
            Title = "Social";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Social go here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };

        }        
    }
}

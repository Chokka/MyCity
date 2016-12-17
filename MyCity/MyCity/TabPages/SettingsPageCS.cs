using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyCity
{
    public class SettingsPageCS : ContentPage
    {
        public SettingsPageCS()
        {
            Icon = "settings.png";
            Title = "Settings";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Settings go here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }
    }
}

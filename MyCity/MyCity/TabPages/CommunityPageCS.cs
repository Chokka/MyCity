using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyCity
{
    public class CommunityPageCS : ContentPage
    {
        public CommunityPageCS()
        {
            Icon = "today.png";
            Title = "Community";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Community Board",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }
    }
}

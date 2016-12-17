using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyCity
{
    public class MainPageCS : TabbedPage
    {
        public MainPageCS()
        {
            var navigationPage = new NavigationPage(new CityPageCS());

            navigationPage.Icon = "today.png";
            navigationPage.Title = "City";

            Children.Add(new SocialPageCS());

            Children.Add(navigationPage);

            Children.Add(new CommunityPageCS());

            Children.Add(navigationPage);

            Children.Add(new SettingsPageCS());
        }

    }
}

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

            var navigationPage = new NavigationPage(new SocialPageCS());
            navigationPage.Icon = "social.png";
            navigationPage.Title = "Social";

            Children.Add(new CityPageCS());
            Children.Add(navigationPage);
            Children.Add(new SettingsPageCS());
        }
    }
}

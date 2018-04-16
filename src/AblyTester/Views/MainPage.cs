using System;

using Xamarin.Forms;

namespace AblyTester
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page startPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:

                    startPage = new NavigationPage(new StartPage())
                    {
                        Title = "Main"
                    };
                    startPage.Icon = "tab_about.png";
                    break;
                default:

                    startPage = new StartPage()
                    {
                        Title = "Main"
                    };
                    break;
            }

            Children.Add(startPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}

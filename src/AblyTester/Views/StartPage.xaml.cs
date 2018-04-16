using System;

using Xamarin.Forms;

namespace AblyTester
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<StartPage, string[]>(this, "DisplayAlert", (sender, args) =>
            {
                DisplayAlert(args[0], args[1], args[2]);
            });

        }
    }
}

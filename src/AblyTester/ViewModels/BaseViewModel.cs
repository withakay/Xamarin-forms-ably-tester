using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

namespace AblyTester
{
    public class BaseViewModel : ObservableObject
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public void DisplayAlert(string title, string message, string buttonText)
        {
            // MessagingCenter.Send(this, "DisplayAlert", new[] {title, message, buttonText});
        }

    }
}

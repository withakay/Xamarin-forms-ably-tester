﻿using System;
namespace AblyTester.Models
{
    public class Message : ObservableObject
    {
        string text;

        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        DateTime messageDateTime;

        public DateTime MessageDateTime
        {
            get { return messageDateTime; }
            set { SetProperty(ref messageDateTime, value); }
        }

        bool isIncoming;

        public bool IsIncoming
        {
            get { return isIncoming; }
            set { SetProperty(ref isIncoming, value); }
        }

        public bool HasAttachement => !string.IsNullOrEmpty(attachementUrl);

        string attachementUrl;
        public string AttachementUrl
        {
            get { return attachementUrl; }
            set { SetProperty(ref attachementUrl, value); }
        }

    }
}

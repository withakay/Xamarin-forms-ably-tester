using System;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Timers;

using Xamarin.Forms;

namespace AblyTester
{
    public class StartViewModel : BaseViewModel
    {
        public StartViewModel()
        {
            Title = "Main Page";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://github.com/ably/ably-dotnet")));

            StartCommand = new Command(() => Start());

            StopCommand = new Command(() => Stop());

            Output = ">";

        }

        Timer _timer;

        IO.Ably.AblyRealtime Realtime { get; set; }

        IO.Ably.Realtime.IRealtimeChannel _channel;
        int _interval = 250;

        public ICommand OpenWebCommand { get; }

        public ICommand StartCommand { get; }

        public ICommand StopCommand { get; }

        private string _output;
        public string Output
        {
            get => _output;
            set { SetProperty(ref _output, value); }
        }

        private void Start() 
        {
            Console.WriteLine("Start called");
            InitAbly();
            Output = "> Running\n";
            Realtime.Connection.Once(IO.Ably.Realtime.ConnectionState.Connected, (args) =>
            {
                _timer = new Timer(_interval);
                _timer.Elapsed += (sender, e) => HandleTimer();
                Output += string.Format("\nSending every {0}ms\n", _interval);
                _timer.Start();
            });
        }

        private void Stop()
        {
            Console.WriteLine("Stop called");
            Output += "\n> Ended";
            _timer.Stop();
        }

        private void HandleTimer()
        {
            Output += ".";
            SendMessage(".");
        }

        private void InitAbly()
        {
            Realtime = new IO.Ably.AblyRealtime(new IO.Ably.ClientOptions
            {
                Key = "Bss0RA.mEUxVg:m4qqgjCIsFvrpIBZ",
                EchoMessages = false
            });

            Realtime.Connection.On(args =>
            {
                Output += "\nConnection State is " + args.Current.ToString();

                if (args.Current == IO.Ably.Realtime.ConnectionState.Connected)
                {
                    Console.WriteLine("Connected");
                    // channels don't get automatically reattached 
                    // if the connection drop, so do that manually
                    foreach (var channel in Realtime.Channels)
                    {
                        channel.Attach();
                    }

                    _channel = Realtime.Channels.Get("tester_" + DateTime.Now.ToLongTimeString());

                }
                if (args.Current == IO.Ably.Realtime.ConnectionState.Disconnected)
                {
                    Realtime.Connect();
                }
            });
        }

        private void SendMessage(string text)
        {
            _channel.Publish("test-message", text);
        }
    }
}

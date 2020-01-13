using System;
using System.Threading.Tasks;
using Shiny;
using Shiny.Notifications;
using Xamarin.Forms;

namespace LocalNotificationsSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override async void OnStart()
        {
            await SchedueLocalNotification(DateTimeOffset.UtcNow.AddSeconds(5));
        }

        Task SchedueLocalNotification(in DateTimeOffset scheduledTime)
        {
            var notification = new Notification
            {
                Title = "Testing Local Notifications",
                Message = "It's working",
                ScheduleDate = scheduledTime
            };

            return ShinyHost.Resolve<INotificationManager>().Send(notification);
        }
    }
}

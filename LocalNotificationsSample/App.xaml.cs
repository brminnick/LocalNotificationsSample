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
            await SendNotificationNow();
            await ScheduleLocalNotification(DateTimeOffset.UtcNow.AddMinutes(1));
        }

        Task SendNotificationNow()
        {
            var notification = new Notification
            {
                Title = "Testing Local Notifications",
                Message = "It's working",
            };

            return ShinyHost.Resolve<INotificationManager>().RequestAccessAndSend(notification);
        }

        Task ScheduleLocalNotification(in DateTimeOffset scheduledDate)
        {
            var notification = new Notification
            {
                Title = "Testing Local Notifications",
                Message = "It's working",
                ScheduleDate = scheduledDate,
            };

            return ShinyHost.Resolve<INotificationManager>().RequestAccessAndSend(notification);
        }
    }
}

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
            await ScheduleLocalNotification(DateTimeOffset.UtcNow.AddSeconds(2));
        }

        Task SendNotificationNow()
        {
            var notification = new Notification
            {
                Title = "Testing Immediate Local Notifications",
                Message = "It's working",
            };

            return ShinyHost.Resolve<INotificationManager>().RequestAccessAndSend(notification);
        }

        Task ScheduleLocalNotification(in DateTimeOffset scheduleDate)
        {
            var notification = new Notification
            {
                Title = "Testing Scheduled Local Notifications",
                Message = $"Scheduled for {scheduleDate}",
                ScheduleDate = scheduleDate,
            };

            return ShinyHost.Resolve<INotificationManager>().RequestAccessAndSend(notification);
        }
    }
}

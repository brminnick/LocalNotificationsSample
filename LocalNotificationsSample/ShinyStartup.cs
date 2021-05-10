using Microsoft.Extensions.DependencyInjection;
using Shiny;

namespace LocalNotificationsSample
{
    public class AppShinyStartup : ShinyStartup
    {
        public override void ConfigureServices(IServiceCollection services, IPlatform platform) => services.UseNotifications();
    }
}

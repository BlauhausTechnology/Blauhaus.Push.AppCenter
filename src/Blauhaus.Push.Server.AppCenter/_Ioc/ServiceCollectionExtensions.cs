using Blauhaus.HttpClientService._Ioc;
using Blauhaus.Ioc.Abstractions;
using Blauhaus.Push.Common.Abstractions;
using Blauhaus.Push.Server.AppCenter.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Push.Server.AppCenter._Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterAppCenterPushNotificationsServer(this IServiceCollection services)
        {
            services.AddScoped<IPushNotificationServerService, AppCenterPushNotificationServerService>();
            services.RegisterClientHttpService();
            return services;
        }
    }
}
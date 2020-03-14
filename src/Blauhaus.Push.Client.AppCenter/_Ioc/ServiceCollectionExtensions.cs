using Blauhaus.Ioc.Abstractions;
using Blauhaus.Push.Client.AppCenter.Service;
using Blauhaus.Push.Common.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Push.Client.AppCenter._Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterAppCenterPushNotificationsClient(this IServiceCollection services)
        {
            services.AddScoped<IPushNotificationClientService, AppCenterPushNotificationClientService>();
            return services;
        }
    }
}
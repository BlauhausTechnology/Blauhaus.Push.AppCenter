using Blauhaus.Ioc.Abstractions;
using Blauhaus.PushNotifications.Client.AppCenter.Service;
using Blauhaus.PushNotifications.Common.Abstractions;

namespace Blauhaus.PushNotifications.Client.AppCenter._Ioc
{
    public static class IocRegistration
    {
        public static IIocService RegisterAppCenterPushNotificationsClient(this IIocService iocService)
        {
            iocService.RegisterImplementation<IPushNotificationClientService, AppCenterPushNotificationClientService>();
            return iocService;
        }
    }
}
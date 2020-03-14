using Blauhaus.Ioc.Abstractions;
using Blauhaus.Push.Client.AppCenter.Service;
using Blauhaus.Push.Common.Abstractions;

namespace Blauhaus.Push.Client.AppCenter._Ioc
{
    public static class IocServiceExtensions
    {
        public static IIocService RegisterAppCenterPushNotificationsClient(this IIocService iocService)
        {
            iocService.RegisterImplementation<IPushNotificationClientService, AppCenterPushNotificationClientService>();
            return iocService;
        }
    }
}
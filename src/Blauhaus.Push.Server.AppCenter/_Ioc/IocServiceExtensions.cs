using Blauhaus.HttpClientService._Ioc;
using Blauhaus.Ioc.Abstractions;
using Blauhaus.Push.Common.Abstractions;
using Blauhaus.Push.Server.AppCenter.Service;

namespace Blauhaus.Push.Server.AppCenter._Ioc
{
    public static class IocServiceExtensions
    {
        public static IIocService RegisterAppCenterPushNotificationsServer(this IIocService iocService)
        {
            iocService.RegisterImplementation<IPushNotificationServerService, AppCenterPushNotificationServerService>();
            iocService.RegisterClientHttpService();
            return iocService;
        }
    }
}
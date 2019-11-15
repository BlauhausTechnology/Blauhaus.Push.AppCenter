﻿using Blauhaus.Ioc.Abstractions;
using Blauhaus.Loggers.Console._Ioc;
using Blauhaus.Push.Common.Abstractions;
using Blauhaus.Push.Server.AppCenter.Service;
using HttpClientService.Core._Ioc;

namespace Blauhaus.Push.Server.AppCenter._Ioc
{
    public static class IocRegisteration
    {
        public static IIocService RegisterAppCenterPushNotificationsServer(this IIocService iocService)
        {
            iocService.RegisterImplementation<IPushNotificationServerService, AppCenterPushNotificationServerService>();
            iocService.RegisterHttpService();
            return iocService;
        }
    }
}
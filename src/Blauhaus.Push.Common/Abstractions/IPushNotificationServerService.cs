using System.Threading.Tasks;
using Blauhaus.Common.Config.AppCenter;
using Blauhaus.Common.Config.AppCenter.Server;
using Blauhaus.PushNotifications.Common.Notifications;

namespace Blauhaus.PushNotifications.Common.Abstractions
{
    public interface IPushNotificationServerService
    {
        Task SendPushNotificationAsync(IPushNotification pushNotification, IAppCenterServerConfig appCenterConfig);
    }
}
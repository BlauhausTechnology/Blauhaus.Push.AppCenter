using System.Threading.Tasks;
using Blauhaus.Common.Config.AppCenter.Server;
using Blauhaus.Push.Common.Notifications;

namespace Blauhaus.Push.Common.Abstractions
{
    public interface IPushNotificationServerService
    {
        Task SendPushNotificationAsync(IPushNotification pushNotification, IAppCenterServerConfig appCenterConfig);
    }
}
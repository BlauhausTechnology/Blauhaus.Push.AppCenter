using System;
using System.Threading.Tasks;

namespace Blauhaus.PushNotifications.Common.Abstractions
{
    public interface IPushNotificationClientService
    {
        Task<string> GetDeviceIdAsync();
    }
}
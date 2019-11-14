using System;
using System.Threading.Tasks;
using Blauhaus.PushNotifications.Common.Abstractions;
using static Microsoft.AppCenter.AppCenter;

namespace Blauhaus.PushNotifications.Client.AppCenter.Service
{
    public class AppCenterPushNotificationClientService : IPushNotificationClientService
    {
        public async Task<string> GetDeviceIdAsync()
        {
            var installId = await GetInstallIdAsync();
            
            return installId == null || installId == Guid.Empty 
                ? string.Empty 
                : installId.ToString();
        }
    }
}
using System;
using System.Threading.Tasks;
using Blauhaus.Push.Common.Abstractions;

namespace Blauhaus.Push.Client.AppCenter.Service
{
    public class AppCenterPushNotificationClientService : IPushNotificationClientService
    {
        public async Task<string> GetDeviceIdAsync()
        {
            var installId = await Microsoft.AppCenter.AppCenter.GetInstallIdAsync();
            
            return installId == null || installId == Guid.Empty 
                ? string.Empty 
                : installId.ToString();
        }
    }
}
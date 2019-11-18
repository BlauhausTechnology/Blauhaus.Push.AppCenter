using System;
using System.Threading;
using System.Threading.Tasks;
using Blauhaus.Common.Config.AppCenter.Server;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.HttpClientService.Request;
using Blauhaus.HttpClientService.Service;
using Blauhaus.Push.Common.Abstractions;
using Blauhaus.Push.Common.Notifications;
using Microsoft.Extensions.Logging;

namespace Blauhaus.Push.Server.AppCenter.Service
{
    public class AppCenterPushNotificationServerService : IPushNotificationServerService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ILogger<AppCenterPushNotificationServerService> _logger;

        public AppCenterPushNotificationServerService(
            IHttpClientService httpClientService,
            ILogger<AppCenterPushNotificationServerService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
        }


        public async Task SendPushNotificationAsync(IPushNotification pushNotification, IAppCenterServerConfig appCenterConfig)
        {

            foreach (var target in pushNotification.DeviceTargets)
            {
                if(!appCenterConfig.AppNames.TryGetValue(target.TargetDevicePlatform, out var appNameForPlatform))
                {
                    _logger.LogWarning("App Center app name not found for " + target.TargetDevicePlatform.Value);
                    return;
                }

                var organizationName = appCenterConfig.OrganizationName;
                var appName = appNameForPlatform;
                var apiEndpoint = $"https://api.appcenter.ms/v0.1/apps/{organizationName}/{appName}/push/notifications";
                var payload = pushNotification.ToAppCenterJsonString(target.TargetDeviceId);
                var apiToken = appCenterConfig.ApiToken;

                var request = new HttpRequestWrapper<string>(apiEndpoint, payload)
                    .WithRequestHeader("X-API-Token", apiToken);

                try
                {
                    await _httpClientService.PostAsync<string, IHttpRequestWrapper<string>>(request, CancellationToken.None);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Failed to send push notification request to app center");
                }
            }

        }

    }
}
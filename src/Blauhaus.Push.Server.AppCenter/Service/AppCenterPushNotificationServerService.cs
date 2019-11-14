using System;
using System.Threading;
using System.Threading.Tasks;
using Blauhaus.Common.Config.AppCenter.Server;
using Blauhaus.Push.Common.Abstractions;
using Blauhaus.Push.Common.Notifications;
using HttpClientService.Core.Request;
using HttpClientService.Core.Service;
using Microsoft.Extensions.Logging;

namespace Blauhaus.Push.Server.AppCenter.Service
{
    public class AppCenterPushNotificationServerService : IPushNotificationServerService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ILogger _logger;

        public AppCenterPushNotificationServerService(
            IHttpClientService httpClientService,
            ILogger logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
        }


        public async Task SendPushNotificationAsync(IPushNotification pushNotification, IAppCenterServerConfig appCenterConfig)
        {
            if(!appCenterConfig.AppNames.TryGetValue(pushNotification.TargetDevicePlatform, out var appNamePlatform))
            {
               //log
               return;
            }

            var organizationName = appCenterConfig.OrganizationName;
            var appName = appNamePlatform;
            var apiEndpoint = $"https://api.appcenter.ms/v0.1/apps/{organizationName}/{appName}/push/notifications";
            var payload = pushNotification.ToAppCenterJsonString();
            var apiToken = appCenterConfig.ApiToken;

            var request = new HttpRequestWrapper<string>(apiEndpoint, payload)
                .WithRequestHeader("X-API-Token", apiToken);

            try
            {
                await _httpClientService.PostAsync<string, IHttpRequestWrapper<string>>(request, CancellationToken.None);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");
                //log
            }
        }

    }
}
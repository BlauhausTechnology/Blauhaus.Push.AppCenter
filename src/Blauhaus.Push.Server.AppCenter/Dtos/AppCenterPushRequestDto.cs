using System;
using System.Collections.Generic;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.Push.Common.Notifications;
using Newtonsoft.Json;

namespace Blauhaus.Push.Server.AppCenter.Dtos
{
    public class AppCenterPushRequestDto
    {

        public AppCenterPushRequestDto()
        {
        }

        public AppCenterPushRequestDto(IPushNotification pushNotification, RuntimePlatform targetTargetDevicePlatform)
        {
            foreach (var deviceTarget in pushNotification.DeviceTargets)
            {
                if (deviceTarget.TargetDevicePlatform.Equals(targetTargetDevicePlatform))
                {
                    NotificationTarget.Devices.Add(deviceTarget.TargetDeviceId);
                }
            }

            NotificationContent = new NotificationContent
            {
                Name = pushNotification.Name, 
                Title = pushNotification.Title, 
                Body = pushNotification.Body,
                CustomData = pushNotification.CustomData
            };
        }

        
        [JsonProperty("notification_target")]
        public NotificationTarget NotificationTarget { get; set; } = new NotificationTarget();
        [JsonProperty("notification_content")]
        public NotificationContent NotificationContent { get; set; } = new NotificationContent();
    }

    public class NotificationTarget
    {
        [JsonProperty("type")] public string Type { get; set; } = "devices_target";

        [JsonProperty("devices")]
        public List<string> Devices { get; set; } = new List<string>();
    }
    public class NotificationContent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("custom_data")]
        public Dictionary<string, string> CustomData { get; set; } = new Dictionary<string, string>();
    }

}
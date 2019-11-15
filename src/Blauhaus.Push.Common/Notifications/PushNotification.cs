using System.Collections.Generic;
using System.Text;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;

namespace Blauhaus.Push.Common.Notifications
{
    public class PushNotification : IPushNotification
    {
        //targeting
        public string TargetUserId { get; set; }
        public List<string> TargetDeviceIds { get; set; } = new List<string>();
        public RuntimePlatform TargetDevicePlatform { get; set; }

        //content
        public string Name { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        //custom data
        public string NotificationType { get; set; } = string.Empty;
        public string Sound { get; set; } = "default";
        public int BadgeCount { get; set; } = 0;
        public string TargetId { get; set; } = string.Empty;

        public string ToAppCenterJsonString()
        {
            var appCenterString = new StringBuilder().Append("{")
                .Append("\"notification_target\": {")
                .Append("\"type\": \"devices_target\", \"devices\": [");

            for (var i = 0; i < TargetDeviceIds.Count; i++)
            {
                appCenterString.Append("\"").Append(TargetDeviceIds[i]).Append("\"").Append(",");
            }

            if (TargetDeviceIds.Count > 0)
            {
                appCenterString.Length -= 1;
            }
            
            appCenterString.Append("]},");
            appCenterString.Append("\"notification_content\": {")
                .Append("\"name\": \"").Append(Name).Append("\", ")
                .Append("\"title\": \"").Append(Title).Append("\", ")
                .Append("\"body\": \"").Append(Body).Append("\", ")
                .Append("\"custom_data\": {")
                .Append("\"notificationType\": \"").Append(NotificationType).Append("\", ")
                .Append("\"badgeCount\": \"").Append(BadgeCount).Append("\", ")
                .Append("\"targetId\": \"").Append(TargetId).Append("\", ")
                .Append("\"sound\": \"").Append(Sound).Append("\"")
                .Append("}")
                .Append("}");

            appCenterString.Append("}");
            return appCenterString.ToString();
        }
    }
}
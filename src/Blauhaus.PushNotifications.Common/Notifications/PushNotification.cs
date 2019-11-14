using System.Text;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;

namespace Blauhaus.PushNotifications.Common.Notifications
{
    public class PushNotification : IPushNotification
    {
        //targeting
        public string TargetUserId { get; set; }
        public string TargetDeviceId { get; set; }
        public RuntimePlatform TargetDevicePlatform { get; set; }

        //content
        public string Name { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        //custom data
        public string NotificationType { get; set; }
        public string SoundFile { get; set; }
        public int BadgeCount { get; set; }
        public string TargetId { get; set; }


        public string ToAppCenterJsonString()
        {
            var appCenterString = new StringBuilder().Append("{")
                .Append("\"notification_target\": {")
                .Append("\"type\": \"devices_target\", \"devices\": [\"").Append(TargetDeviceId).Append("\"]")
                .Append("},");
            appCenterString.Append("\"notification_content\": {")
                .Append("\"name\": \"").Append(Name).Append("\", ")
                .Append("\"title\": \"").Append(Title).Append("\", ")
                .Append("\"body\": \"").Append(Body).Append("\", ")
                .Append("\"custom_data\": {")
                .Append("\"notificationType\": \"").Append(NotificationType).Append("\", ")
                .Append("\"badgeCount\": \"").Append(BadgeCount).Append("\", ")
                .Append("\"targetId\": \"").Append(TargetId).Append("\", ")
                .Append("\"soundFile\": \"").Append(SoundFile).Append("\"")
                .Append("}")
                .Append("}");

            appCenterString.Append("}");
            return appCenterString.ToString();
        }
    }
}
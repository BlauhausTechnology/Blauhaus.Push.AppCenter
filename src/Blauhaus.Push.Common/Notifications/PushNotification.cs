using System.Collections.Generic;
using System.Text;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;

namespace Blauhaus.Push.Common.Notifications
{
    public class PushNotification : IPushNotification
    {
        //targeting
        public string TargetUserId { get; set; }
        public List<PushNotificationTarget> DeviceTargets { get; set; } = new List<PushNotificationTarget>();

        //content
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;

        //custom data
        public string NotificationType
        {
            get => CustomData["notificationType"];
            set => CustomData["notificationType"] = value;
        }

        public string Sound 
        {
            get => CustomData["sound"];
            set => CustomData["sound"] = value;
        }

        public int BadgeCount
        {
            get => int.Parse(CustomData["badgeCount"]);
            set => CustomData["badgeCount"] = value.ToString();
        }

        public string TargetId
        {
            get => CustomData["targetId"];
            set => CustomData["targetId"] = value;
        }

        public Dictionary<string, string> CustomData { get; } = new Dictionary<string, string>
        {
            {"notificationType", "" },
            {"targetId", "" },
            {"badgeCount", "0" },
            {"sound", "default" },
        };

    }
}
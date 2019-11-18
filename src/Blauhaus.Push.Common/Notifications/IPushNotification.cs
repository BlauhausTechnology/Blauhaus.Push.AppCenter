using System.Collections.Generic;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;

namespace Blauhaus.Push.Common.Notifications
{
    public interface IPushNotification
    {

        string TargetUserId { get; set; }
        List<PushNotificationTarget> DeviceTargets { get; set; } 

        string Name { get; set; } 
        string Title { get; set; } 
        string Body { get; set; } 
        string Sound { get; set; }
        int BadgeCount { get; set; }
        string TargetId { get; set; }
        string NotificationType { get; set; }
        Dictionary<string, string> CustomData { get; }
    }
}
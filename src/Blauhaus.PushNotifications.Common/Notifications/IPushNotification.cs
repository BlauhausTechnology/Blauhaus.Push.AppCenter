using Blauhaus.Common.ValueObjects.RuntimePlatforms;

namespace Blauhaus.PushNotifications.Common.Notifications
{
    public interface IPushNotification
    {
        string NotificationType { get; set; }

        string TargetUserId { get; set; }
        string TargetDeviceId { get; set; }
        RuntimePlatform TargetDevicePlatform { get; set; }

        string Name { get; set; } 
        string Title { get; set; } 
        string Body { get; set; } 
        string SoundFile { get; set; }
        int BadgeCount { get; set; }
        string TargetId { get; set; }
        
        string ToAppCenterJsonString();
    }
}
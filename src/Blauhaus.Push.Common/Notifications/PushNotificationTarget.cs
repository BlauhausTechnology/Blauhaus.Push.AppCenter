using System.Collections.Generic;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;

namespace Blauhaus.Push.Common.Notifications
{
    public class PushNotificationTarget
    {
        public string TargetDeviceId { get; set; }
        public RuntimePlatform TargetDevicePlatform { get; set; }
    }
}
using Newtonsoft.Json;

namespace Blauhaus.Push.Server.AppCenter.Dtos
{
    public class AppCenterPushResponseDto
    {
        [JsonProperty("notification_id")]
        public string AppCenterNotificationId { get; set; }
    }
}
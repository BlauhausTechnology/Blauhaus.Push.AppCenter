using Blauhaus.PushNotifications.Common.Notifications;
using Blauhaus.Tests.Helpers;
using NUnit.Framework;

namespace Blauhaus.PushNotifications.Tests.Tests.Common.PushNotificationsTests
{
    public class ToJsonStringTests: BaseUnitTest<PushNotification>
    {
        protected override PushNotification ConstructSut()
        {
            return new PushNotification();
        }


        [Test]
        public void SHOULD_add_TargetDeviceId_as_device_target()
        {
            //Arrange
            Sut.TargetDeviceId = "targetDeviceId";
            Sut.Name = "NAME";
            Sut.Title = "TITLE";
            Sut.Body = "BODY";
            Sut.TargetId = "ID";
            Sut.NotificationType = "Chat";
            Sut.SoundFile = "SOUND";
            Sut.BadgeCount = 111;

            //Act
            var result = Sut.ToAppCenterJsonString();

            //Assert
            Assert.That(result, Is.EqualTo("{\"notification_target\": {\"type\": \"devices_target\", \"devices\": [\"targetDeviceId\"]},\"notification_content\": {\"name\": \"NAME\", \"title\": \"TITLE\", \"body\": \"BODY\", \"custom_data\": {\"notificationType\": \"Chat\", \"badgeCount\": \"111\", \"targetId\": \"ID\", \"soundFile\": \"SOUND\"}}}"));
        }
        
    }
}
using System.Collections.Generic;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.Push.Common.Notifications;
using Blauhaus.Tests.Helpers;
using NUnit.Framework;

namespace Blauhaus.Push.Tests.Tests.Common.PushNotificationsTests
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
            Sut.TargetDeviceIds = new List<string> {"targetDeviceId" };
            Sut.Name = "NAME";
            Sut.Title = "TITLE";
            Sut.Body = "BODY";
            Sut.TargetId = "ID";
            Sut.NotificationType = "Chat";
            Sut.Sound = "SOUND";
            Sut.BadgeCount = 111;

            //Act
            var result = Sut.ToAppCenterJsonString();

            //Assert
            Assert.That(result, Is.EqualTo("{\"notification_target\": {\"type\": \"devices_target\", \"devices\": [\"targetDeviceId\"]},\"notification_content\": {\"name\": \"NAME\", \"title\": \"TITLE\", \"body\": \"BODY\", \"custom_data\": {\"notificationType\": \"Chat\", \"badgeCount\": \"111\", \"targetId\": \"ID\", \"sound\": \"SOUND\"}}}"));
        }

        [Test]
        public void IF_there_are_multiple_devices_SHOULD_add_them_all()
        {
            //Arrange
            Sut.TargetDeviceIds = new List<string> {"targetDeviceId1", "targetDeviceId2", "targetDeviceId3" };
            Sut.Name = "NAME";
            Sut.Title = "TITLE";
            Sut.Body = "BODY";
            Sut.TargetId = "ID";
            Sut.NotificationType = "Chat";
            Sut.Sound = "SOUND";
            Sut.BadgeCount = 111;

            //Act
            var result = Sut.ToAppCenterJsonString();

            //Assert
            Assert.That(result, Is.EqualTo("{\"notification_target\": {\"type\": \"devices_target\", \"devices\": [\"targetDeviceId1\",\"targetDeviceId2\",\"targetDeviceId3\"]},\"notification_content\": {\"name\": \"NAME\", \"title\": \"TITLE\", \"body\": \"BODY\", \"custom_data\": {\"notificationType\": \"Chat\", \"badgeCount\": \"111\", \"targetId\": \"ID\", \"sound\": \"SOUND\"}}}"));
        }

      
        
    }
}
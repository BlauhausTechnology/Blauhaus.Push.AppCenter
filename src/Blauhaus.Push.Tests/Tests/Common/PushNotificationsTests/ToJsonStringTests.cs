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
            Sut.DeviceTargets = new List<PushNotificationTarget>
            {
                new PushNotificationTarget{TargetDeviceId = "targetDeviceId"}
            };
            Sut.Name = "NAME";
            Sut.Title = "TITLE";
            Sut.Body = "BODY";
            Sut.TargetId = "ID";
            Sut.NotificationType = "Chat";
            Sut.Sound = "SOUND";
            Sut.BadgeCount = 111;

            //Act
            var result = Sut.ToAppCenterJsonString("targetDeviceId");

            //Assert
            Assert.That(result, Is.EqualTo("{\"notification_target\": {\"type\": \"devices_target\", \"devices\": [\"targetDeviceId\"]},\"notification_content\": {\"name\": \"NAME\", \"title\": \"TITLE\", \"body\": \"BODY\", \"custom_data\": {\"notificationType\": \"Chat\", \"badgeCount\": \"111\", \"targetId\": \"ID\", \"sound\": \"SOUND\"}}}"));
        }

        [Test]
        public void IF_there_are_multiple_devices_SHOULD_add_requested_one_only()
        {
            //Arrange
            Sut.DeviceTargets = new List<PushNotificationTarget>
            {
                new PushNotificationTarget{TargetDeviceId = "targetDeviceId1"},
                new PushNotificationTarget{TargetDeviceId = "targetDeviceId2"},
                new PushNotificationTarget{TargetDeviceId = "targetDeviceId3"}
            };
            Sut.Name = "NAME";
            Sut.Title = "TITLE";
            Sut.Body = "BODY";
            Sut.TargetId = "ID";
            Sut.NotificationType = "Chat";
            Sut.Sound = "SOUND";
            Sut.BadgeCount = 111;

            //Act
            var result = Sut.ToAppCenterJsonString("targetDeviceId2");

            //Assert
            Assert.That(result, Is.EqualTo("{\"notification_target\": {\"type\": \"devices_target\", \"devices\": [\"targetDeviceId2\"]},\"notification_content\": {\"name\": \"NAME\", \"title\": \"TITLE\", \"body\": \"BODY\", \"custom_data\": {\"notificationType\": \"Chat\", \"badgeCount\": \"111\", \"targetId\": \"ID\", \"sound\": \"SOUND\"}}}"));
        }

      
        
    }
}